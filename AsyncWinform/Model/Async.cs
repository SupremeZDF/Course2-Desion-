using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AsyncWinform.Model
{
    public class Async
    {
        public static async Task GetName() 
        {
            Debug.WriteLine("213");
            //return Task.Run(()=> { });
            await Task.Run(() => 
            {
                for (var i = 0; i < 5; i++) 
                {
                    Thread.Sleep(1000);
                }
            });

            //await Task.Run(() =>
            //{
            //    for (var i = 0; i < 5; i++)
            //    {
            //        Thread.Sleep(1000);
            //    }
            //});

            //await Task.Run(() =>
            //{
            //    for (var i = 0; i < 5; i++)
            //    {
            //        Thread.Sleep(1000);
            //    }
            //});
            Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);
            //return 1;
        }
    }
}
