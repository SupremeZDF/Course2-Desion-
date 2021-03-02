using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DesinSixtenet.SignModel
{
    public class DesignOnemodel
    {
        //设计模式6大原则

        //1 单一职责原则
        //2 里氏替换原则
        //3 依赖倒置原则
        //4 接口隔离原则
        //5 迪米特法则
        //6 开闭原则

        //单一职责原则
        //类 单一职责原则（类 项目 系统 方法 类 ）
        public static void OnlyTnnet()
        {
            //类 单一职责原则（类  项目 系统 方法 类 ）
            Thread thread = new Thread(() => { });
        }

        //里氏替换
        //里氏替换原则 任何使用基类的地方 ，那可以透明的使用子类
        //继承 多态
        //继承： 字类拥有父类的一切属性和行为，任何父类出现的地方都可以，都可以用字类代替
        //继承+加透明 （安全，不会出现行为不一致）
        //如果在继承中子类出现没有的 应断开继承 （违背里氏替换原则）
        //子类可以有自己的属性和行为
        //父类实现的东西 子类不就用重写了
        // 如果需要重写 则使用抽象/虚写
        // 声明 字段 、属性 、变量 尽量申明为父类
        public static void ReplaceTnnet()
        {
            aa.cc();
            //aa aa=new aa()
        }

        // 迪米法特原则 （最少知道原则）
        // 一个对象应该对其他对象保持最少的了解
        // 只与直接的朋友通信
        // 面向对象语言 -- 万物皆对象 -- 类与类 交互才能产生功能 - （耦合）
        // 高类聚低耦合
        //类与类之间的关系 
        public static void DMFTTnnet() 
        {
        
        }
    }

    public abstract class aa
    {
        public void Name() { }

        public static void cc() { }

    }

    public class cc : aa 
    {
       
    }
}
