using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;

namespace AsyncWinform.Model
{
    public class HomeWorkClass
    {

        public const string Nmae = "123";

        static HomeWorkClass() 
        {
            string totalPath = ConfigurationSettings.AppSettings["LogFile"].ToString();
            if (!File.Exists(totalPath))
            {
                File.Create(totalPath);
            }
        }

        public static int FirstEvent = 0;

        public static int FastEvent = 0;

        public readonly static object FirstObj = new Object();

        public readonly static object FastObj = new Object();



        /// <summary>
        /// 获取 Json 
        /// </summary>
        /// <returns></returns>
        public static List<JsonModel> jsonModels()
        {
            var config = ConfigurationSettings.AppSettings["jsonFile"].ToString();
            string file = File.ReadAllText(config);
            var jsonconvert = JsonConvert.DeserializeObject<List<JsonModel>>(file);
            var json = JsonConvert.SerializeObject(jsonconvert);
            return jsonconvert;
        }

        public static void DebugColor(string msg,ConsoleColor consoleColor) 
        {
            lock (FirstObj) 
            {
                foreach (var i in msg.ToCharArray())
                {
                    Thread.Sleep(30);
                    Console.ForegroundColor = consoleColor;
                    Debug.Write(i);
                }
                //Console.WriteLine("");
            }
        }

        //打印日志
        public static void Log(string msg) 
        {
            try
            {
                //string fileName = "log.txt";
                lock (FastObj) 
                {
                    var logFile = ConfigurationSettings.AppSettings["LogFile"].ToString();
                    using (StreamWriter sw = File.AppendText(logFile))
                    {
                        sw.WriteLine($"{DateTime.Now.ToString()}:{msg}");
                        sw.WriteLine($"*************************************");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        //乔峰
        public static void QF()
        {
            Thread.Sleep(OneModelRun.GetRandomInt(1000, 5000));
            Debug.WriteLine("乔峰: This is 丐帮帮主");
            lock (FirstObj)
            {
                if (FirstEvent == 0)
                {
                    FirstEvent++;
                    Debug.WriteLine("天龙八部就此拉开序幕");
                }
            }
            Thread.Sleep(OneModelRun.GetRandomInt(3000, 7000));
            Debug.WriteLine("乔峰: This is 契丹人");
            Thread.Sleep(OneModelRun.GetRandomInt(3000, 7000));
            Debug.WriteLine("乔峰: This is 西夏驸马");
            Thread.Sleep(OneModelRun.GetRandomInt(3000, 7000));
            Debug.WriteLine("乔峰: This is 挂印离开");
            lock (FastObj)
            {
                if (FastEvent == 0)
                {
                    FastEvent++;
                    Debug.WriteLine("乔峰完成任务了");
                }
            }
        }

        //虚竹
        public static void XZ()
        {
            Thread.Sleep(OneModelRun.GetRandomInt(1000, 5000));
            Debug.WriteLine("虚竹: This is 小和尚");
            lock (FirstObj)
            {
                if (FirstEvent == 0)
                {
                    FirstEvent++;
                    Debug.WriteLine("天龙八部就此拉开序幕");
                }
            }
            Thread.Sleep(OneModelRun.GetRandomInt(3000, 7000));
            Debug.WriteLine("虚竹: This is 逍遥掌门");
            Thread.Sleep(OneModelRun.GetRandomInt(3000, 7000));
            Debug.WriteLine("虚竹: This is 岭路宫掌门");
            Thread.Sleep(OneModelRun.GetRandomInt(3000, 7000));
            Debug.WriteLine("虚竹: This is 西夏驸马");
            lock (FastObj)
            {
                if (FastEvent == 0)
                {
                    FastEvent++;
                    Debug.WriteLine("虚竹完成任务了");
                }
            }
        }

        //段誉
        public static void DY()
        {
            Thread.Sleep(OneModelRun.GetRandomInt(1000, 5000));
            Debug.WriteLine("段誉: This is 钟灵儿");
            lock (FirstObj)
            {
                if (FirstEvent == 0)
                {
                    FirstEvent++;
                    Debug.WriteLine("天龙八部就此拉开序幕");
                }
            }
            Thread.Sleep(OneModelRun.GetRandomInt(3000, 7000));
            Debug.WriteLine("段誉: This is 木婉清");
            Thread.Sleep(OneModelRun.GetRandomInt(3000, 7000));
            Debug.WriteLine("段誉: This is 王语嫣");
            Thread.Sleep(OneModelRun.GetRandomInt(3000, 7000));
            Debug.WriteLine("段誉: This is 大理国王");
            lock (FastObj)
            {
                if (FastEvent == 0)
                {
                    FastEvent++;
                    Debug.WriteLine("段誉完成任务了");
                }
            }
        }
    }
}
