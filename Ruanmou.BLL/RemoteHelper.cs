using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.BLL
{
    /// <summary>
    /// 远程接口
    /// </summary>
    public class RemoteHelper
    {
        public static List<T> Query<T>(int index)
        {
            Console.WriteLine("This is {0} Query", typeof(RemoteHelper));
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
