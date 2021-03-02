using AsyncWinform.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace AsyncWinform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Task> tasks = new List<Task>();
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            //ManualResetEvent manualResetEvent = new ManualResetEvent(false);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            tasks.Add(Task.Run(() => 
            {
                try
                {
                    HomeWorkClass.DY();
                }
                catch (Exception ex)
                {

                }
            }, cancellationTokenSource.Token));

            tasks.Add(Task.Run(() =>
            {
                HomeWorkClass.QF();
            }, cancellationTokenSource.Token));

            tasks.Add(Task.Run(()=> 
            {
                HomeWorkClass.XZ();
            }, cancellationTokenSource.Token));

            TaskFactory taskFactory = new TaskFactory();

            taskFactory.ContinueWhenAll(tasks.ToArray(),s=> 
            {
                //foreach (var i in s) 
                //{

                //}
                stopwatch.Stop();
                Debug.WriteLine("中原群雄大战辽兵，忠义两难一死谢天");
                Debug.WriteLine($"完成所消耗时间{stopwatch.ElapsedMilliseconds}");
            });

            Task.Factory.StartNew(() => 
            {
                Random random = new Random();
                while (true)
                {
                    var i = random.Next(0, 4000);
                    if (i == 2019)
                    {
                        cancellationTokenSource.Cancel();
                        Debug.WriteLine("天降雷霆灭世，天龙八部的故事就此结束。。。");
                    }
                    return;
                }
            });

            //var s = 123;

            //taskFactory.StartNew<int>( s =>  12 ,12, cancellationTokenSource.Token);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            {
                ManualResetEvent manualResetEvent = new ManualResetEvent(false);

                ThreadPool.QueueUserWorkItem(s =>
                {
                    for (var i = 0; i < 5; i++)
                    {
                        Thread.Sleep(500);
                        Debug.WriteLine(i);
                    }
                    manualResetEvent.Set();
                });
                //break;
                Task.Run(() =>
                {
                    manualResetEvent.WaitOne();
                });
            }


        }

        public readonly static object obj = new object();

        //获取json 
        private void button3_Click(object sender, EventArgs e)
        {
            List<JsonModel> LogFile = HomeWorkClass.jsonModels();
            List<Task> tasks = new List<Task>();
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            var j = 0;
            //
            foreach (var mode in LogFile) 
            {
                tasks.Add(Task.Run(() => 
                {

                    {
                        //var jj = 0;
                        //foreach (var i in mode.Exercise)
                        //{
                        //    if (jj == 0)
                        //    {
                        //        //Thread.Sleep(OneModelRun.GetRandomInt(1000, 5000));

                        //        lock (obj)
                        //        {
                        //            HomeWorkClass.DebugColor(i, ConsoleColor.Red);
                        //            jj++;
                        //            if (j == 0)
                        //            {
                        //                Debug.WriteLine("拉开序幕");
                        //            }
                        //            j++;
                        //        }

                        //    }
                        //    else
                        //    {
                        //        HomeWorkClass.DebugColor(i, ConsoleColor.Red);
                        //    }

                        //}
                    }

                    foreach (var log in mode.Exercise) 
                    {
                        if (j == 0) //第一次全部等 双判断锁
                        {
                            lock (obj) 
                            {
                                HomeWorkClass.DebugColor(log, ConsoleColor.Red);
                                if (j == 0) 
                                {
                                    Debug.WriteLine("拉开序幕");
                                    j++;
                                }
                            }
                        }
                        else 
                        {
                            HomeWorkClass.DebugColor(log, ConsoleColor.Red);
                        }
                        if (cancellationTokenSource.IsCancellationRequested) 
                        {
                            break;
                        }
                    }
                }, cancellationTokenSource.Token));
            }
            Task.Factory.ContinueWhenAny(tasks.ToArray(),(s) => {
                Debug.WriteLine("准备就绪");
            }, cancellationTokenSource.Token);

            Task.Factory.StartNew(() =>
            {
                Random random = new Random();
                while (true)
                {
                    if (random.Next(2000, 2040) == 2019)
                    {
                        cancellationTokenSource.Cancel();
                        Debug.WriteLine("天降雷霆灭世，天龙八部的故事就此结束。。。");
                        return;
                    }
                }
            });
            //foreach(var i in )
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            List<JsonModel> LogFile = HomeWorkClass.jsonModels();

            var u = 0;

            foreach (var i in LogFile) 
            {
                Task.Run(() => 
                {
                    var j = i;
                    foreach (var ii in j.Exercise) 
                    {
                        if (u == 0)
                        {
                            lock (obj) 
                            {
                                HomeWorkClass.DebugColor(ii, ConsoleColor.Red);
                                if (u == 0) 
                                {
                                    Debug.WriteLine("天降雷霆灭世，天龙八部的故事就此结束。。。");
                                    u++;
                                }
                            }
                        }
                        else 
                        {
                            HomeWorkClass.DebugColor(ii, ConsoleColor.Red);
                        }
                    }
                });
            }
        }
    }
}
