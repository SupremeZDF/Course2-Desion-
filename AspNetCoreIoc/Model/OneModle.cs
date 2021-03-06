using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity;
using Unity.Extension;
using System.Reflection;

namespace AspNetCoreIoc.Model
{
    //[AttributeUsage(AttributeTargets.Constructor,AllowMultiple =false,Inherited = false )]
    public class OneModle
    {

        //依赖倒置原则 DIP 系统架构时 高层模块不应该依赖于底层模块 二者通过抽象来依赖    (依赖抽象 而不是细节)
        //面向抽象： 1一个方法能满足多种类型 2 支持下层的扩展
        //ioc  传统 ：上端依赖 （调用/指定）下端对象 ，会有依赖 把对下端对象的依赖转移到第三方容器（工厂+配置文件+反射）
        //能够程序拥有更好的扩展性

        //DI 依赖注入 ： 依赖注入就是能够做到构造某个对象时，将依赖的对象自动初始化并注入 
        //三种注入方式：构造-属性-方法（注入_时间）
        public static void OneRun() 
        {
            IUnityContainer Unity = new UnityContainer();
            //Unity.RegisterType

            //Activator.CreateInstance();
        }
    }
}
