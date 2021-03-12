using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CLRCore.OneRun
{
    public class OneCacheRun
    {
        // 分片保存缓存数据 提高缓存性能
        private static List<Dictionary<string, object>> keyValuePairs = new List<Dictionary<string, object>>(); //缓存数据容器

        private static List<object> List = new List<object>(); // 不同容器对应不同的锁

        private static int fpContainer = 0; // 容器数量

        //初始化容器 减少容器的影响范围
        static OneCacheRun()
        {
            fpContainer = 3;
            for (var i = 0; i < fpContainer; i++)
            {
                keyValuePairs.Add(new Dictionary<string, object>());
                List.Add(new object());
            }

            //开启线程 清理缓存 每隔 10分钟 清理 一次数据
            Task.Run(() => 
            {
                while (true) 
                {
                    Thread.Sleep(1000 * 5); //等待10分钟
                    try
                    {
                        for (var i = 0; i < 3; i++)
                        {
                            lock (List[i]) //清理过期缓存 减少影响范围
                            {
                                List<string> vs = new List<string>();
                                foreach (var j in keyValuePairs[i].Keys) 
                                {
                                    ModelDate modelDate = (ModelDate)keyValuePairs[i][j];
                                    if (modelDate.cacheType != CacheType.Never && modelDate.DeadLine < DateTime.Now)
                                    {
                                        vs.Add(j);
                                    }
                                }
                                vs.ForEach(s=> keyValuePairs[i].Remove(s)); //删除过期数据
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var message = ex.Message;
                    }
                }
            });
        }

        public static bool Remove(string key) 
        {
            int hash = key.GetHashCode();//相对均匀而且稳定
            int index = Math.Abs(hash % 3);
            lock (List[index])  //删除
            {
                keyValuePairs[index].Remove(key);
                return true;
            }
        }

        public static void Get(string key)
        {
            int hash = key.GetHashCode();//相对均匀而且稳定
            int index = Math.Abs(hash % 3);
            if (keyValuePairs[index].ContainsKey(key)) 
            {
                lock (List[index])  //获取
                {
                    var model = keyValuePairs[index][key];
                }
            }
        }

        public static void Add(string key, object obj) 
        {
            int hash = key.GetHashCode();//相对均匀而且稳定
            int index = Math.Abs(hash % 3);

            lock (List[index])  //获取
            {
                if (!keyValuePairs[index].ContainsKey(key))
                {
                    keyValuePairs[index].Add(key, obj);
                    //return true;
                }
            }
        }

        /// <summary>
        /// 访问数据 
        /// </summary>
        public static bool FWData(string key)
        {
            var hashCode = key.GetHashCode();
            //获取key相对应的容器
            var cg = Math.Abs(hashCode % 3);

            if (keyValuePairs[cg].ContainsKey(key))
            {
                lock (List[cg])
                {
                    ModelDate modelDate = (ModelDate)keyValuePairs[cg][key];
                    //永久
                    if (modelDate.cacheType == CacheType.Never)
                    {
                        return true;
                    }
                    else if (modelDate.DeadLine < DateTime.Now)
                    {
                        keyValuePairs[cg].Remove(key);
                        return false;
                    }
                    else 
                    {
                        //滑动过期
                        if (modelDate.cacheType == CacheType.Relative) 
                        {
                            modelDate.DeadLine = DateTime.Now.Add(modelDate.TimeSpan);
                        }
                        return true;
                    }

                }
            }
            else
            {
                return false;
            }

        }
    }

    public class ModelDate
    {
        //过期策略
        //永久有效 -- 目前就是
        //绝对过期 -- 有个时间点 超过就过期
        //滑动过期 -- 多久之后过期 滑动过期 如果期间更新/查询 ，就再次延长
        public object Value { get; set; }

        //过期时间
        public DateTime DeadLine { get; set; }

        //滑动过期时间间隔
        public TimeSpan TimeSpan { get; set; }

        //缓存数据过期机制
        public CacheType cacheType { get; set; }
    }

    public enum CacheType
    {
        Never,  //永久有效
        Absolote,   //一段时间有效
        Relative   // 滑动过期
    }
}
