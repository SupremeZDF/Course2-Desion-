using Common;
using Ruanmou.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyCache
{
    /// <summary>
    /// 1 客户端缓存-CDN缓存-反向代理缓存-本地缓存
    /// 2 本地缓存原理和手写基础实现
    /// 
    /// 系统性能优化的第一步，就是使用缓存
    /// 缓存：实际上是一种效果&目标，就是获取数据的时候，第一次获取之后找个地方存起来，后面直接用，这样一来可以提升后面每次获取数据的效率
    /// 读取配置文件的时候把信息放在静态字段，这个就是缓存
    /// 缓存是无所不在的。。
    /// 
    /// 
    /// 1 缓存数据更新和过期策略
    /// 2 多线程冲突与解决 
    /// 3 缓存类库封装和缓存应用总结
    /// 
    /// 
    /// 缓存究竟哪里用？ 满足哪些特点适合用缓存？
    /// 访问频繁+耗时耗资源+相对稳定+体积不那么大
    /// 不是说严格满足，看情况，存一次能查3次，就值得缓存(大型项目标准)
    /// 字典/省市区/配置文件
    /// 公告信息/部门/权限/用户
    /// 热搜/类别列表/产品列表
    /// 
    /// 股票价格数据/彩票开奖信息  不行，即时性要求很高
    /// 图片/视频   不行，体积太大
    /// 商品评论  可以的，虽然评论会变，但是这不重要，而且第一页一般不变
    /// 
    /// 
    /// 可以测试一下CustomCache的性能，十万/百万/千万 插入&获取&删除的性能
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("欢迎来到.net高级班vip课程，今天是Eleven老师为大家带来的缓存Cache");
                {
                    #region MyRegion
                    ////1 重复请求--100人访问首页--每个人做的其实都一样--不就是重复
                    ////2 耗时/耗资源
                    ////3 结果没变
                    ////应该缓存一下，来提升性能
                    //Console.WriteLine("********************************");
                    //for (int i = 0; i < 5; i++)
                    //{
                    //    Console.WriteLine($"获取{nameof(DBHelper)} {i}次 {DateTime.Now.ToString("yyyyMMdd HHmmss.fff")}");
                    //    //List<Program> programList = DBHelper.Query<Program>(123);
                    //    List<Program> programList = null;
                    //    string key = $"{nameof(DBHelper)}_Query_{123}";
                    //    //存取数据的唯一标识:1 唯一的  2 能重现
                    //    //if (!CustomCache.Exists(key))
                    //    //{
                    //    //    programList = DBHelper.Query<Program>(123);
                    //    //    CustomCache.Add(key, programList);
                    //    //}
                    //    //else
                    //    //{
                    //    //    programList = CustomCache.Get<List<Program>>(key);
                    //    //}
                    //    programList = CustomCache.GetT<List<Program>>(key, () => DBHelper.Query<Program>(123));
                    //}
                    //Console.WriteLine("********************************");
                    //for (int i = 0; i < 5; i++)
                    //{
                    //    Console.WriteLine($"获取{nameof(FileHelper)} {i}次 {DateTime.Now.ToString("yyyyMMdd HHmmss.fff")}");
                    //    //List<Program> programList = FileHelper.Query<Program>(234);
                    //    List<Program> programList = null;
                    //    string key = $"{nameof(FileHelper)}_Query_{234}";
                    //    //存取数据的唯一标识:1 唯一的  2 能重现
                    //    //if (!CustomCache.Exists(key))
                    //    //{
                    //    //    programList = FileHelper.Query<Program>(234);
                    //    //    CustomCache.Add(key, programList);
                    //    //}
                    //    //else
                    //    //{
                    //    //    programList = CustomCache.Get<List<Program>>(key);
                    //    //}
                    //    programList = CustomCache.GetT<List<Program>>(key, () => FileHelper.Query<Program>(234));
                    //}
                    //Console.WriteLine("********************************");
                    //for (int i = 0; i < 5; i++)
                    //{
                    //    Console.WriteLine($"获取{nameof(RemoteHelper)} {i}次 {DateTime.Now.ToString("yyyyMMdd HHmmss.fff")}");
                    //    //List<Program> programList = RemoteHelper.Query<Program>(345);
                    //    List<Program> programList = null;
                    //    string key = $"{nameof(RemoteHelper)}_Query_{345}";
                    //    //存取数据的唯一标识:1 唯一的  2 能重现
                    //    //if (!CustomCache.Exists(key))
                    //    //{
                    //    //    programList = RemoteHelper.Query<Program>(345);
                    //    //    CustomCache.Add(key, programList);
                    //    //}
                    //    //else
                    //    //{
                    //    //    programList = CustomCache.Get<List<Program>>(key);
                    //    //}
                    //    programList = CustomCache.GetT<List<Program>>(key, () => RemoteHelper.Query<Program>(345));
                    //}
                    #endregion
                }
                {
                    //for (int i = 0; i < 5; i++)
                    //{
                    //    Console.WriteLine($"获取{nameof(DBHelper)} {i}次 {DateTime.Now.ToString("yyyyMMdd HHmmss.fff")}");
                    //    //List<Program> programList = DBHelper.Query<Program>(123);

                    //    List<Program> programList = null;
                    //    string key = $"{nameof(DBHelper)}_Query_{123}";
                    //    //存取数据的唯一标识:1 唯一的  2 能重现
                    //    if (!CustomCache.Exists(key))
                    //    {
                    //        programList = DBHelper.Query<Program>(123);
                    //        CustomCache.Add(key, programList);
                    //    }
                    //    else
                    //    {
                    //        programList = CustomCache.Get<List<Program>>(key);
                    //    }
                    //}
                    ////缓存优化性能，核心就是结果重用，下一次请求还是用上一次的结果
                    ////如果数据有变化怎么办呢？ 岂不是用了一个错误的数据？ 
                    ////是的。。缓存难免会有脏数据， 当然了，我们也会分门别类去尽量减少脏数据
                    //{
                    //    //用户-角色-菜单  用户权限查的多+比较耗资源+相对稳定，非常适合缓存，缓存方式应该是用户id为key，菜单列表为value
                    //    string name = "Eleven_menu__Menu";
                    //    List<string> menu = new List<string>();
                    //    if (!CustomCache.Exists(name))
                    //    {
                    //        menu = new List<string>() { "123", "125553", "143", "123456" };
                    //        CustomCache.Add(name, menu);
                    //    }
                    //    else
                    //    {
                    //        menu = CustomCache.Get<List<string>>(name);
                    //    }
                    //}
                    //{
                    //    //1 Eleven的权限变化了,缓存应该失效
                    //    //数据更新影响单条缓存，常规做法是Remove掉 而不是更新
                    //    //因为缓存只是用来提升效率的，而不是数据保存的，因此的不需要更新，只需要删除就好，如果真的下次用上了，到时候再去初始化
                    //    string name = "Eleven_menu__Menu";
                    //    CustomCache.Remove(name);

                    //    List<string> menu = new List<string>();
                    //    if (!CustomCache.Exists(name))
                    //    {
                    //        menu = new List<string>() { "123", "125553", "143" };
                    //        CustomCache.Add(name, menu);
                    //    }
                    //    else
                    //    {
                    //        menu = CustomCache.Get<List<string>>(name);
                    //    }
                    //}
                    //{
                    //    //2 删除了某个菜单，影响了一大批用户

                    //    //全部干掉，殃及池鱼(最模糊)
                    //    CustomCache.RemoveAll();

                    //    //根据菜单--找角色--找用户--每一个拼装key然后去Remove(最精准)
                    //    //这个不行，为了缓存增加数据库的任务，最大的问题是数据量的问题，缓存是二八原则，只有20%的热点用户才缓存，像这样成本太高

                    //    //菜单删除了，能不能只影响一部分的缓存数据
                    //    //1 添加缓存时，key带上规则，比如权限包含_menu_
                    //    //2 清理时就只删除key含_menu_的
                    //    CustomCache.RemoveCondition(s => s.Contains("_menu_"));
                    //}
                    //{
                    //    //3 第三方修改了数据，缓存并不知道，这个没办法
                    //    //a 可以调用接口清理缓存，b系统修改数据，调用c系统通知下缓存更新
                    //    //b 就只能容忍了。容忍脏数据。但是可以加上时间限制，减少影响时间
                    //}
                    {
                        //多线程问题
                        List<Task> taskList = new List<Task>();
                        for (int i = 0; i < 1_000_000; i++)
                        {
                            int k = i;
                            taskList.Add(Task.Run(() => CustomCache.Add($"TestKey_{k}", $"TestValue_{k}", 10)));
                        }
                        for (int i = 0; i < 100; i++)
                        {
                            int k = i;
                            taskList.Add(Task.Run(() => CustomCache.Remove($"TestKey_{k}")));
                        }
                        for (int i = 0; i < 100; i++)
                        {
                            int k = i;
                            taskList.Add(Task.Run(() => CustomCache.Exists($"TestKey_{k}")));
                        }
                        //Thread.Sleep(10*1000);
                        Task.WaitAll(taskList.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
