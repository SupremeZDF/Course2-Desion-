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
                IUnityContainer unityContainer = new UnityContainer();
                unityContainer.RegisterType(typeof(InstaceOne), typeof(A));
                //var ban = unityContainer.Resolve(typeof(InstaceOne));
                unityContainer.RegisterType(typeof(IocExercise), typeof(B));
                unityContainer.RegisterType<InstaceOne, A>(new SingletonLifetimeManager()) ;
                var I = unityContainer.Resolve(typeof(IocExercise));
            }

            { }

            {
                //IUnityContainer unityContainer = new UnityContainer();
                //unityContainer.RegisterType(typeof(InstaceOne), typeof(A));
                ////var ban = unityContainer.Resolve(typeof(InstaceOne));
                //unityContainer.RegisterType(typeof(IocExercise), typeof(B));
                //unityContainer.RegisterType(typeof(B), typeof(C));
                //var I = unityContainer.Resolve(typeof(IocExercise));

                IOCCZuo iOCCZuo = new IOCCZuo();
                iOCCZuo.RrgisterType<IocExercise, B>();
                var d = iOCCZuo.Resove<IocExercise>();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                IUnityContainer unityContainer = new UnityContainer();
                IUnityContainer unityContainers = new UnityContainer();
                unityContainer.RegisterType<IocExercise, B>(new SingletonLifetimeManager());
                unityContainers.RegisterType<IocExercise, B>(new SingletonLifetimeManager());
                var d1 = unityContainer.CreateChildContainer();
                var d2 = unityContainer.CreateChildContainer();

                var obj1 = d1.Resolve<IocExercise>();
                var obj2 = d2.Resolve<IocExercise>();
                var obj4 = unityContainer.Resolve<IocExercise>();
                var obj5 = object.ReferenceEquals(obj1, obj2);
                var obj6 = object.ReferenceEquals(obj2, obj4);

                //var obj1 = unityContainer.Resolve<IocExercise>();
                //var obj2 = unityContainers.Resolve<IocExercise>();
                //var obj3 = object.ReferenceEquals(obj1,obj2);

                //AsyncResult
                Action action = new Action(() => { });
                action.BeginInvoke(s=> { },null);
         
            }

            {
                //CallContext.SetData();
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
