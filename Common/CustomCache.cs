using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 第三方数据存储和获取的地方
    /// 
    /// 过期策略：
    /// 永久有效---目前就是
    /// 绝对过期---有个时间点，超过就过期
    /// 滑动过期---多久之后过期，如果期间更新/查询/检查存在，就再次延长
    /// 
    /// 主动清理+被动清理，保证过期数据不会被查询；过期数据也不会滞留太久
    /// 
    /// 多线程操作非线程安全的容器，会造成冲突
    /// 1 线程安全容器ConcurrentDictionary
    /// 2 用lock---Add/Remove/遍历 解决问题了，但是性能怎么办呢
    ///   怎么降低影响，提升性能呢？
    ///   多个数据容器，多个锁，容器之间可以并发
    /// </summary>
    public class CustomCache //: ICache
    {
        //ConcurrentDictionary

        private static readonly object CustomCache_Lock = new object();

        /// <summary>
        /// 主动清理
        /// </summary>
        static CustomCache()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        List<string> keyList = new List<string>();
                        lock (CustomCache_Lock)
                        {
                            foreach (var key in CustomCacheDictionary.Keys)
                            {
                                DataModel model = (DataModel)CustomCacheDictionary[key];
                                if (model.ObsloteType != ObsloteType.Never && model.DeadLine < DateTime.Now)
                                {
                                    keyList.Add(key);
                                }
                            }
                            keyList.ForEach(s => Remove(s));
                        }
                        Thread.Sleep(1000 * 60 * 10);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        continue;
                    }
                }
            });
        }

        /// <summary>
        /// private:私有一下数据容器，安全
        /// static：不被GC
        ///   字典：读写效率高
        /// </summary>
        //private static Dictionary<string, object> CustomCacheDictionary = new Dictionary<string, object>();

        private static Dictionary<string, object> CustomCacheDictionary = new Dictionary<string, object>();

        public static void Add(string key, object oVaule)
        {
            lock (CustomCache_Lock)
                CustomCacheDictionary.Add(key, new DataModel()
                {
                    Value = oVaule,
                    ObsloteType = ObsloteType.Never,
                });
        }
        /// <summary>
        /// 绝对过期
        /// </summary>
        /// <param name="key"></param>
        /// <param name="oVaule"></param>
        /// <param name="timeOutSecond"></param>
        public static void Add(string key, object oVaule, int timeOutSecond)
        {
            lock (CustomCache_Lock)
                CustomCacheDictionary.Add(key, new DataModel()
                {
                    Value = oVaule,
                    ObsloteType = ObsloteType.Absolutely,
                    DeadLine = DateTime.Now.AddSeconds(timeOutSecond)
                });
        }
        /// <summary>
        /// 相对过期
        /// </summary>
        /// <param name="key"></param>
        /// <param name="oVaule"></param>
        /// <param name="duration"></param>
        public static void Add(string key, object oVaule, TimeSpan duration)
        {
            lock (CustomCache_Lock)
                CustomCacheDictionary.Add(key, new DataModel()
                {
                    Value = oVaule,
                    ObsloteType = ObsloteType.Relative,
                    DeadLine = DateTime.Now.Add(duration),
                    Duration = duration
                });
        }

        /// <summary>
        /// 要求在Get前做Exists检测
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Get<T>(string key)
        {
            return (T)(((DataModel)CustomCacheDictionary[key]).Value);
        }

        /// <summary>
        /// 被动清理，请求了数据，才能清理
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool Exists(string key)
        {
            if (CustomCacheDictionary.ContainsKey(key))
            {
                DataModel model = (DataModel)CustomCacheDictionary[key];
                if (model.ObsloteType == ObsloteType.Never)
                {
                    return true;
                }
                else if (model.DeadLine < DateTime.Now)//现在已经超过你的最后时间
                {
                    lock (CustomCache_Lock)
                        CustomCacheDictionary.Remove(key);
                    return false;
                }
                else
                {
                    if (model.ObsloteType == ObsloteType.Relative)//没有过期&是滑动 所以要更新
                    {
                        model.DeadLine = DateTime.Now.Add(model.Duration);
                    }
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除key
        /// </summary>
        /// <param name="key"></param>
        public static void Remove(string key)
        {
            lock (CustomCache_Lock)
                CustomCacheDictionary.Remove(key);
        }

        public static void RemoveAll()
        {
            lock (CustomCache_Lock)
                CustomCacheDictionary.Clear();
        }
        /// <summary>
        /// 按条件删除
        /// </summary>
        /// <param name="func"></param>
        public static void RemoveCondition(Func<string, bool> func)
        {
            List<string> keyList = new List<string>();
            lock (CustomCache_Lock)
                foreach (var key in CustomCacheDictionary.Keys)
                {
                    if (func.Invoke(key))
                    {
                        keyList.Add(key);
                    }
                }
            keyList.ForEach(s => Remove(s));
        }

        public static T GetT<T>(string key, Func<T> func)
        {
            T t = default(T);
            if (!CustomCache.Exists(key))
            {
                t = func.Invoke();
                CustomCache.Add(key, t);
            }
            else
            {
                t = CustomCache.Get<T>(key);
            }
            return t;
        }
    }

    public class CustomCacheNew
    {
        //动态初始化多个容器和多个锁
        private static int CPUNumer = 0;//获取系统的CPU数
        private static List<Dictionary<string, object>> DictionaryList = new List<Dictionary<string, object>>();
        private static List<object> LockList = new List<object>();
        static CustomCacheNew()
        {
            CPUNumer = 4;
            for (int i = 0; i < CPUNumer; i++)
            {
                DictionaryList.Add(new Dictionary<string, object>());
                LockList.Add(new object());
            }

            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(1000 * 60 * 10);
                    try
                    {
                        for (int i = 0; i < CPUNumer; i++)
                        {
                            List<string> keyList = new List<string>();
                            lock (LockList[i])//减少锁的影响范围
                            {
                                foreach (var key in DictionaryList[i].Keys)
                                {
                                    DataModel model = (DataModel)DictionaryList[i][key];
                                    if (model.ObsloteType != ObsloteType.Never && model.DeadLine < DateTime.Now)
                                    {
                                        keyList.Add(key);
                                    }
                                }
                                keyList.ForEach(s => DictionaryList[i].Remove(s));
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        continue;
                    }
                }
            });
        }

        //假如给你个key，你怎么知道在哪里？ 需要多一个规则
        public static void Add(string key, object oValue)
        {
            int hash = key.GetHashCode();//相对均匀而且稳定
            int index = hash % CPUNumer;
            lock (LockList[index])
            {
                DictionaryList[index].Add(key, oValue);
            }
        }

        public static void Remove(string key)
        {
            int hash = key.GetHashCode();//相对均匀而且稳定
            int index = hash % CPUNumer;
            lock (LockList[index])
            {
                DictionaryList[index].Remove(key);
            }
        }



    }

    /// <summary>
    /// 缓存的信息
    /// </summary>
    internal class DataModel
    {
        public object Value { get; set; }
        public ObsloteType ObsloteType { get; set; }
        public DateTime DeadLine { get; set; }
        public TimeSpan Duration { get; set; }

        //数据清理后出发事件
        public event Action DataClearEvent;
    }

    public enum ObsloteType
    {
        Never,
        Absolutely,
        Relative
    }
}
