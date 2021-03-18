using DataStructure.Run;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Modle
{
    public class TwoRunDD 
    {

        public string Name { get; set; }

        public static void OneRun() 
        {
            List<int> vs = new List<int>();
        }

        public static void TwoRun()
        {
            //List<int> vs = new List<int>();
            
            //set 纯碎的集合 唯一性 去重 元素间没有关系 动态增加容量
            {
                //统计数据  IP 地址
                HashSet<int> vs = new HashSet<int>();
                vs.Add(1);
                vs.Add(2);
                vs.Add(1);
                vs.Add(3);
                vs.Add(5);
                vs.Add(2);
                foreach (var i in vs) 
                {
                    var j = i;
                }

                HashSet<int> vss = new HashSet<int>();
                vss.Add(3);
                vss.Add(4);
                vss.Add(5);
                vss.Add(6);
                vss.Add(7);
                vss.Add(10);

                //差集
                vs.ExceptWith(vss);
                //交集
                vs.IntersectWith(vss);
                //补集
                vs.SymmetricExceptWith(vss);
                //并集
                vs.UnionWith(vss);
            }
            //
            {
                //排序的集合：去重 而且排序
                //统计排名
                SortedSet<string> vs = new SortedSet<string>();
                vs.Add("123");
                vs.Add("233");
                vs.Add("1223");
                vs.Add("123");
                vs.Add("4123");
                vs.Add("2123");

                foreach (var j in vs) 
                {
                    var i = j;
                }
            }

            {
                Hashtable hashtable = new Hashtable();
                hashtable.Add("1", "1");
                //hashtable.Add("1", "1");
                hashtable.Add("2", "2");
                hashtable.Add("12", "12");
                hashtable.Add("123", "123");
                hashtable.Add("q", "q123");

                foreach (var j in hashtable) 
                {
                    var i = j;
                }

                Dictionary<string, string> keyValuePairs1 = new Dictionary<string, string>();

                keyValuePairs1.Add("1", "1");
                keyValuePairs1.Add("2", "2");
                keyValuePairs1.Add("12", "12");
                keyValuePairs1.Add("123", "123");
                keyValuePairs1.Add("q", "q123");

                foreach (var j in keyValuePairs1) 
                {
                    var i = j;
                    
                }

                SortedDictionary<string, string> keyValuePairs = new SortedDictionary<string, string>();

                SortedList sortedList = new SortedList();

                IQueryable vs; 
            }
        }

        // 
        public static void ThreeRun() 
        {
            List<int> vs = new List<int>();
            IEnumerable enumerable;
            vs.Add(1);
            //yield
        }

        public static void FourRun() 
        {
            OneRunDiDai<StuDent> oneRunDiDai = new Run.OneRunDiDai<StuDent>();
            for (var i = 0; i < 10; i++) 
            {
                oneRunDiDai.Add(new StuDent { ID = i, Name = $"N_{i}", Age = $"A_{i}" });
            }
            {
                IEnumerable<StuDent> stuDents = oneRunDiDai;
                var d = stuDents.GetEnumerator();
                IEnumerable enumerable = oneRunDiDai;
                var dd = enumerable.GetEnumerator();
            }
            {
                var d = oneRunDiDai.GetEnumerator();
                while (d.MoveNext())
                {
                    Debug.WriteLine(d.Current.Name);
                }

                var s = ((IEnumerable)oneRunDiDai).GetEnumerator();

                foreach (StuDent stuDent in oneRunDiDai)
                {
                    Debug.WriteLine(stuDent.Name);
                }
            }
           
        }

        public static async Task AA() 
        {
           BB();
        }
        public static async Task BB()
        {
            var i = 1;
            //await Task.Run(()=> { });
            var j = 1;
        }
    }
}
