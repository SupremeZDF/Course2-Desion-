using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRCore.Model
{

    public interface AAS 
    {
    
    }

    public struct AA : AAS   //结构不能有父类  隐式继承了 ValueType
    {
    
    }

    public class OneModel
    {
        //堆栈内存分配
        //堆 Heap ： 一个程序运行时，该进程存放引用类型变量的一块内存 ,全局唯一（整个应用程序只有一个堆）
        //栈 Stack ： 先进后出数据结构 线程栈 ，一个线程存放的变量内存 , 随着线程生命周期
        //值类型分配在栈上面 (枚举 结构)
        //引用类型分配在堆上面 (委托 接口 类 string)
        public static void OneRun() 
        {
            //引用类型调用 new 的时候 会在堆上面开辟一个内存 创建实例
            //把实列的引用传递给构造函数
            //执行构造函数
            //返回引用

            //值类型的值 会随着对象的位置存储
            //引用类型的值 一定在堆里面
            //值类型的长度是确定的 ，引用类型的长度不是确定的（只有堆才能放各种类型的值） 栈空间有限 
        }

        public static void TwoRun()
        {

        }
    }
}
