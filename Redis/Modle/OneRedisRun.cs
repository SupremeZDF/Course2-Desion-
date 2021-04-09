using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ServiceStack;

namespace Redis.Modle
{
    public class OneRedisRun
    {
        //32位一个进程 最多2g缓存 64位 最多4g
        //分布式缓存  - 远程服务器内存管理数据 提供读写数据，效率更高
        //分布式缓存： Memcached 
        //             No-Sql

        //数据库的复杂 ：好友关系（张三有100个好友），映射表冗余，关系数据库开始累赘(数据库读写和写入压力，硬盘速度不能满足，大量数据)
        //
        //No_Sql 特点：基于内存：没有严格的数据格式
        //丰富的类型，满足 web2.0

        //Redis : Remote DictionNary Serverce 远程字典服务器
        //基于内存管理 （数据存在内存） 实现了5种数据结构（分别应对各种具体需求），单线程模型的应用程序（单进程单线程）对外提供插入-查询-固化-集群功能

        // string  list hash set zset

        //单线程：原子性操作 要么都成功 ，要么都失败，不会出现中间状态

        /// <summary>
        /// 
        /// </summary>
        public static void Onerunredis() 
        {
            var g = true;
            {
                using (RedisStringService service = new RedisStringService())
                {

                    UserName userName = new UserName()
                    {
                        ID = 0 ,
                        Name ="KN",
                        Age=12
                    };

                    service.StoreAsHash<UserName>(userName);

                    //Thread.Sleep(3000);
                    //if (g)
                    //{
                    //    var count = service.DecyValue("k10");
                    //    if (count >= 0)
                    //    {
                    //        Debug.WriteLine($"号");
                    //    }
                    //    else
                    //    {
                    //        g = false;
                    //        Debug.WriteLine($"{count}");
                    //    }
                    //}
                    //var dd = service.GetAllItemsFromSet();
                }
            }

            for (var i = 0; i < 100; i++)
            {
                Task.Run(() =>
                {
                    using (RedisStringService service = new RedisStringService())
                    {
                        //Thread.Sleep(3000);
                        if (g)
                        {
                            var count = service.DecyValue("k10");
                            if (count >= 0)
                            {
                                Debug.WriteLine($"号");
                            }
                            else
                            {
                                g = false;
                                Debug.WriteLine($"{count}");
                            }
                        }
                    }
                });
            }
        }
    }
}
