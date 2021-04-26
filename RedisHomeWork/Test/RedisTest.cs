using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RedisHomeWork.Test
{
    public class RedisTest
    {
        private static bool IsGoOn = true;// 秒杀活动是否结束
        private static int Stock = 0;  //  
        public static void Show()
        {
            Stock = 10;  //物品数量
            for (int i = 0; i < 5000; i++)
            {
                int k = i; 
                Task.Run(() =>//每个线程就是一个用户请求
                {
                    if (IsGoOn)
                    {
                        long index = Stock;//-1并且返回 去数据库查一下当前的库存
                        Thread.Sleep(100);
                        if (index >= 1)
                        {
                            Stock = Stock - 1;//更新库存
                            Console.WriteLine($"{k.ToString("000")}秒杀成功，秒杀商品索引为{index}");
                            //可以分队列，去数据库操作
                        }
                        else
                        {
                            if (IsGoOn)
                            {
                                IsGoOn = false;
                            }
                            Console.WriteLine($"{k.ToString("000")}秒杀失败，秒杀商品索引为{index}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{k.ToString("000")}秒杀停止......");
                    }
                });
            }
            Console.Read();
        }


        private static List<string> UserList = new List<string>()
        {
            "Tenk","花生","Ray","阿莫西林","石昊","ywa"
        };
        //public static void Show()
        //{
        //    using (RedisZSetService service = new RedisZSetService())
        //    {
        //        service.FlushAll();//清理全部数据

        //        Task.Run(() =>
        //        {
        //            while (true)
        //            {
        //                foreach (var user in UserList)
        //                {
        //                    Thread.Sleep(10);
        //                    service.IncrementItemInSortedSet("陈一发儿", user, new Random().Next(1, 100));//表示在原来刷礼物的基础上增加礼物
        //                }
        //                Thread.Sleep(20 * 1000);
        //            }
        //        });

        //        Task.Run(() =>
        //        {
        //            while (true)
        //            {
        //                Thread.Sleep(12 * 1000);
        //                Console.WriteLine("**********当前排行************");
        //                int i = 1;

        //                foreach (var item in service.GetAllWithScoresFromSortedSet("陈一发儿"))
        //                {
        //                    Console.WriteLine($"第{i++}名 {item.Key} 分数{item.Value}");
        //                }
        //                //foreach (var item in service.GetAllDesc("陈一发儿"))
        //                //{
        //                //    Console.WriteLine($"第{i++}名 {item}");
        //                //}
        //            }
        //        });
        //        Console.Read();
        //    }
        //}
    }
}
