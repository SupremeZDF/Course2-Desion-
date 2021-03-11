using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.BLL
{
    /// <summary>
    /// 数据库查询
    /// </summary>
    public class DBHelper
    {
        /// <summary>
        /// 1 耗时耗资源
        /// 2 参数固定时，结果不变
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="index"></param>
        /// <returns></returns>
        public static List<T> Query<T>(int index)
        {
            Console.WriteLine("This is {0} Query", typeof(DBHelper));
            long lResult = 0;
            for (int i = index; i < 1000000000; i++)
            {
                lResult += i;
            }
            List<T> tList = new List<T>();
            for (int i = 0; i < index % 3; i++)
            {
                tList.Add(default(T));
            }

            return tList;
        }

    }
}
