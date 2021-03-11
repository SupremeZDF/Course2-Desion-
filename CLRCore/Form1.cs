using CLRCore.Model;
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

namespace CLRCore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 4、什么时候 执行垃圾回收 GC
        // a) new() 对象时-临界点（） （内存不够 垃圾回收 new 创建对象）
        // b) GC.Collect() 强制执行 内存溢出
        // c) 程序退出时会 GC
        private void button1_Click(object sender, EventArgs e)
        {
            //垃圾回收时 会优先回收 0 代 提升效率 最多也容易释放
            //TwoModel twoModel = new TwoModel();
            //twoModel = null;
            //GC.Collect();
            TwoModel.IOneRun();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TwoModel.ITwoRun();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //using (ThreeModelRun s = new ThreeModelRun()) 
            //{
            while (true) 
            {
                using (ThreeModelRun s = new ThreeModelRun()) 
                {
                
                }
            }
            //GC.Collect();
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
              
            }
            {
                string a = new string("123".ToCharArray());
                string aa = new string("123".ToCharArray());
                Debug.WriteLine(a);
                Debug.WriteLine(aa);
                Debug.WriteLine(object.ReferenceEquals(a, aa));

                Debug.WriteLine("-----------------------------");

                string s = "123";
                string ss = "123";
                Debug.WriteLine(s);
                Debug.WriteLine(ss);
                Debug.WriteLine(object.ReferenceEquals(s, ss));
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //object obj = new object();
            //for (var i = 0; i < 3; i++) 
            //{
            //    Task.Run(() =>
            //    {
            //        var j = 1;
            //        object objs = obj;
            //        Debug.WriteLine(j.GetHashCode() + "_" + objs.GetHashCode());
            //        Thread.Sleep(10 * 1000);
            //    });
            //}

            {
                //OneModelClass oneModelClass = new OneModelClass() { A = "1", B = "3" };
                //OneModelClass oneModelClass1 = oneModelClass;
                //oneModelClass1.A = "4";
                //oneModelClass1.A = "6";

                //oneModelClass = null;
            }

            {
                //DateTime.Now.Add();
                //Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

                //try
                //{
                //    List<Task> tasks = new List<Task>();

                //    tasks.Add(Task.Run(() =>
                //    {
                //        for (var i = 1; i < 1000; i++) 
                //        {
                //            Thread.Sleep(10);
                //            keyValuePairs.Add($"{i}", $"{i}");
                //        }
                //    }));
                //    tasks.Add(Task.Run(() =>
                //    {
                //        try
                //        {
                //            Thread.Sleep(2000);
                //            foreach (var i in keyValuePairs)
                //            {
                //                Thread.Sleep(10);
                //                var j = keyValuePairs[$"{i}"];
                //            }
                //        }
                //        catch (Exception ex)
                //        {
                //            var es = ex.Message;
                //            throw;
                //        }
                       
                //    }));
                //    tasks.Add(Task.Run(() =>
                //    {
                       
                //        try
                //        {
                //            for (var i = 1; i < 1000; i++)
                //            {
                //                Thread.Sleep(2000);
                //                keyValuePairs.Remove($"{i}");
                //            }

                //        }
                //        catch (Exception ex)
                //        {
                //            var es = ex.Message;
                //            throw;
                //        }
                //    }));
                //    Task.WaitAll(tasks.ToArray());
                //}
                //catch (Exception ex)
                //{
                //    var es = ex.Message;
                //    throw;
                //}
            }

            ICustomDictionnary.IFiveRun();
        }
    }

    public class OneModelClass 
    {
        public string A { get; set; }

        public string B { get; set; }
    }
}
