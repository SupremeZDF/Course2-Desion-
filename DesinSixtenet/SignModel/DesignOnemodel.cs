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
        //纵向 ： 继承  实现
        //横向 ： 聚合 组合 包含 依赖(包含在方法内部)
        //高内聚低耦合
        //迪米特法则，降低类与类的之间的耦合
        //  只与直接的朋友通信 ，尽量避免依赖更多类型
        // 迪米特 会增加一些成本 
        public static void DMFTTnnet() 
        {
        
        }

        //依赖倒置原则
        //高层模块不应该依赖底层模块 二者应该通过抽象依赖抽象 而不是依赖细节
        //抽象： 接口/抽象类 - 可以包含没有实现的元素
        //细节 ： 普通类 - 一切都市确定的
        // 面向抽象编程

        //面向对象 只要抽象不变，高层就不变
        //面向抽象优点
        //面向对象语言开发，类与类之间交互，高层直接依赖底层的细节 细节是多变的
        //底层的变换导致上层的变化 
        public static void YLDZTnnet() 
        {

        }

        // 接口隔离原则
        // 客户户端不应该依赖他他不需要的接口 一个类 对另一个类的依赖应该建立在最小的接口上
        // 
        public static void JKGLTnnet() 
        {
            IList<int> vs = new List<int>();
        }

        //开闭原则
        // 修改 ：修改现有代码（类）
        // 扩展 ：增加代码（类）
        // 面向对象就是增加类i 对源有代码没有改动 原有的代码才是可信的
        // 
        public static void onOFFTnnet() 
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
