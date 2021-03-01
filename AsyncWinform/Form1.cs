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

            taskFactory.StartNew(() => 
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

        //获取json 
        private void button3_Click(object sender, EventArgs e)
        {
            List<JsonModel> jsonModels = HomeWorkClass.jsonModels();

            //foreach(var i in )
        }
    }
}
