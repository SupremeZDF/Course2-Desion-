using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.Web;
using Redis.Modle;

namespace Redis
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //{
            //    byte[] vs = Encoding.UTF8.GetBytes("哈哈");
            //    string s = "";
            //    for (var i = 0; i < vs.Length; i++)
            //    {
            //        //var l = vs[i];
            //        s += $"{vs[i].ToString("x2")}";
            //    }

            //    var byteCount = s.Length / 2;
            //    var result = new byte[byteCount];

            //    for (int ii = 0; ii < byteCount; ++ii)
            //    {
            //        //var tempBytes = Byte.Parse(s.Substring(2 * ii, 2), System.Globalization.NumberStyles.HexNumber);
            //        var tempBytes = Convert.ToByte(s.Substring(2 * ii, 2), 16);
            //        result[ii] = tempBytes;
            //    }

            //    var str = Encoding.UTF8.GetString(result);
            //}

            //{
            //    //byte[] vs =  { 225 ,11};
            //    //var str = "";

            //    //for (var i = 0; i < vs.Length; i++) 
            //    //{
            //    //    str += Convert.ToString(vs[i],2);
            //    //}

            //    byte i = 0;
            //    byte ii = 16;
            //    var y = i.ToString("x2");
            //    var yy = ii.ToString("x2");
            //}

            //{
            //    string ss = "00001000000001";

            //    var sss = Convert.ToInt32(ss, 2);

            //    string dd = Encoding.UTF8.GetString("");
            //}


            //var t = Convert.ToSByte(s, 16);
            //var ty = Encoding.UTF8.GetString(vs);
            //string[] chars = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //byte[] returnBytes = new byte[chars.Length];
            //for (int i = 0; i < chars.Length; i++)
            //{
            //    returnBytes[i] = Convert.ToByte(chars[i], 16);
            //}

            {
                //var s = name;
                //var u = name;
                //s.id = 10;
                //name = null;
                //u = new Name { id = 2 };
              
                //var uu = s;

            }

            {
                //using (RedisStringService service = new RedisStringService()) 
                //{
                //    var s = service.Set<string>("k4","4" ,TimeSpan.FromSeconds(20));

                    
                //}
            }

            {
                OneRedisRun.Onerunredis();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static Name name = new Name { id = 1 };
    }

    public class Name 
    {
       public int id { get; set; }
    }
}
