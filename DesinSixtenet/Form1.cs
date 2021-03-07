using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity.Extension;
using Unity;
using DesinSixtenet.Ioc;
using Unity.Lifetime;
using System.Runtime.Remoting.Messaging;
using System.Diagnostics;
using System.Threading;

namespace DesinSixtenet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var c = AA.bb;
            c.Age = 12;
            c.Name = "hah1";
            var dd = AA.bb;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            {
                //IUnityContainer unityContainer = new UnityContainer();
                //unityContainer.RegisterType(typeof(InstaceOne), typeof(A));
                ////var ban = unityContainer.Resolve(typeof(InstaceOne));
                //unityContainer.RegisterType(typeof(IocExercise), typeof(B));
                //unityContainer.RegisterType(typeof(B), typeof(C));
                //var I = unityContainer.Resolve(typeof(IocExercise));

                IOCCZuo iOCCZuo = new IOCCZuo();
                iOCCZuo.RrgisterType<IocExercise, B>(enumLifeCicle.Transfrom);
                iOCCZuo.RrgisterType<C,C>(enumLifeCicle.Singlon);
                iOCCZuo.RrgisterType<D,D>(enumLifeCicle.ThreadSinglon);
                var d = iOCCZuo.Resove<IocExercise>();
                var dd = iOCCZuo.Resove<IocExercise>();
            }

            {
                IUnityContainer unityContainer = new UnityContainer();
                unityContainer.RegisterType(typeof(InstaceOne), typeof(A));
                //var ban = unityContainer.Resolve(typeof(InstaceOne));
                unityContainer.RegisterType(typeof(IocExercise), typeof(B));
                unityContainer.RegisterType<InstaceOne, A>(new SingletonLifetimeManager());
                var I = unityContainer.Resolve(typeof(IocExercise));
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                //CallContext.SetData();
                //线程槽
                var s = true;
                for (var i = 0; i < 3; i++) 
                {
                    var h = i;
                    Task.Run(() =>
                    {
                        var jj = h;
                        CallContext.SetData($"{jj}",jj);
                        while (s) 
                        {
                            
                            Debug.WriteLine($"数字{jj}_{Thread.CurrentThread.ManagedThreadId}_值——{CallContext.GetData($"{jj}")}");
                            Thread.Sleep(1500);
                        }
                        Debug.WriteLine($"数字_{jj}_{Thread.CurrentThread.ManagedThreadId}_值——{CallContext.GetData($"{1}")}");
                        Debug.WriteLine($"数字_{jj}_{Thread.CurrentThread.ManagedThreadId}_值——{CallContext.GetData($"{3}")}");
                        Debug.WriteLine($"数字_{jj}_{Thread.CurrentThread.ManagedThreadId}_值——{CallContext.GetData($"{2}")}");
                    });
                }
                Task.Run(() =>
                {
                    Thread.Sleep(10000);
                    s = false;
                    Debug.WriteLine($"数字_4_{Thread.CurrentThread.ManagedThreadId}_值——{CallContext.GetData($"{1}")}");
                    Debug.WriteLine($"数字_4_{Thread.CurrentThread.ManagedThreadId}_值——{CallContext.GetData($"{3}")}");
                    Debug.WriteLine($"数字_4_{Thread.CurrentThread.ManagedThreadId}_值——{CallContext.GetData($"{2}")}");
                });
            }
            {
                //IUnityContainer unityContainer = new UnityContainer();
                //IUnityContainer unityContainers = new UnityContainer();
                //unityContainer.RegisterType<IocExercise, B>(new SingletonLifetimeManager());
                //unityContainers.RegisterType<IocExercise, B>(new SingletonLifetimeManager());
                //var d1 = unityContainer.CreateChildContainer();
                //var d2 = unityContainer.CreateChildContainer();

                //var obj1 = d1.Resolve<IocExercise>();
                //var obj2 = d2.Resolve<IocExercise>();
                //var obj4 = unityContainer.Resolve<IocExercise>();
                //var obj5 = object.ReferenceEquals(obj1, obj2);
                //var obj6 = object.ReferenceEquals(obj2, obj4);

                //var obj1 = unityContainer.Resolve<IocExercise>();
                //var obj2 = unityContainers.Resolve<IocExercise>();
                //var obj3 = object.ReferenceEquals(obj1,obj2);

                //AsyncResult
                //Action action = new Action(() => { });
                //action.BeginInvoke(s=> { },null);
            }
        }
    }

    public class AA
    {
        public static AA bb = new AA() { Name = "123", Age = 123 };

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
