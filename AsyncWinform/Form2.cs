using AsyncWinform.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncWinform
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private readonly static object h = new object();

        private void button1_Click(object sender, EventArgs e)
        {
            List<JsonModel> LogFile = HomeWorkClass.jsonModels();
            List<Task> tasks = new List<Task>();
            var iii = 0;
            foreach (var i in LogFile) 
            {
                Task.Run(() => 
                {
                    var j = i;
                    var ii = 0;
                    
                    foreach (var u in j.Exercise) 
                    {
                        if (ii == 0)
                        {
                            HomeWorkClass.DebugColor(u, ConsoleColor.Red);
                            lock (h) 
                            {
                                if (iii == 0)
                                {
                                    Debug.WriteLine("拉开序幕");
                                }
                                iii++;
                            }
                        }
                        else 
                        {
                            HomeWorkClass.DebugColor(u, ConsoleColor.Red);
                        }
                        ii++;
                    }
                });
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Task> tasks = new List<Task>();

            object[] values = { "a", "b", "c", "d", "e" };

            IterationSample collection = new IterationSample(values, 3);
            foreach (object x in collection)
            {
                Debug.WriteLine(x);
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            //Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);
            //await Async.GetName();
            ////Task.WaitAll(c);
            //Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);

           ForeRun();
        }

        public async  Task OneRun() 
        {
            Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);
            TwoRun();
            //Task.WaitAll(c);
            Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }

        public static async Task TwoRun() 
        {
            Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);
            await Task.Run(()=> { });
            await ThreeRun();
            //Task.WaitAll(c);
            Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }

        public static async Task ThreeRun()
        {
            Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);
            ForeRun();
            //Task.WaitAll(c);
            Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);
            //Thread thread = new Thread();
        }

        public static async  Task ForeRun()
        {
            Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);
            await Async.GetName();
            //Task.WaitAll(c);
            Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);
            //Thread thread = new Thread();
            //return null;
        }
    }
}
