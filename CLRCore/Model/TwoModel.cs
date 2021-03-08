using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CLRCore.Model
{
    public class TwoModel
    {
        //  1、托管垃圾回收 - 垃圾回收
        // 什么样的对象需要来及回收
        // (托管资源+引用资源) 会垃圾回收(引用类型)


        // 托管资源和非托管资源
        // 托管的就是 CLR 控制的 new 的对象 string 字符串 变量
        // 非托管不是 CLR 控制的 ， 数据库链接 文件流 句柄 打印机链接
        // using(sqlconnection) 被c#封装了管理了非托管的数据库链接资源
        // 只要是手动释放的，都是非托管的


        // 线程结束 线程栈内存会被销毁 不需要垃圾回收
        // 2、那些对象的内存 能被GC回收
        // 对象用不到了，会被GC垃圾回收

        // 3、对象是如何分配在堆上的
        // 对象连续分配在堆上面 ，每次分配就先检查空间够不够



        // 4、什么时候 执行垃圾回收 GC
        // a) new() 对象时-临界点（） （内存不够 垃圾回收 new 创建对象）
        // b) GC.Collect() 强制执行 内存溢出
        // c) 程序退出时会 GC




        //  5、GC的过程是怎么样的呢？
        //  new个对象触发 （ N个对象--全部对象标记为垃圾 -入口开始遍历-访问到的就标记为可以访问(+1)）
        //  遍历完就清理内存 - 产生不连续内存 - 地址移动 - 修改变量指向 - 所以会全局阻塞
        //
        //  清理内存分为两种情况  
        //  a) 无析构函数   
        //  b）有析构函数 ,不能直接移出 会把对象转移到单独的队列 ，会有个析构器线程专门做这个 
        //        通常在析构函数内部都是用来做非托管资源释放，因为CLR肯定调用，所以避免使用浙忘记的情况



        // 6、 垃圾回收策略 
        //     垃圾分代
        //     对象分代：0代 第一次分配到堆就是0代
        //               1代 经历了一次GC 已然还在的
        //               2代 经历了两次或以上GC 已然还在的
        //    垃圾回收时 会优先回收 0 代 提升效率 最多也容易释放

        //    0 代不够 -找一代 - 1代不够找二代 
        //
        //    大对象堆 
        //       一是内存移动大对象 二是0代空间问题
        //       80000字节就叫大对象 没有分代 直接都市二代

        public static void IOneRun()
        {
            {
                //遍历完就清理内存 - 产生不连续内存 - 地址移动 - 修改变量指向 - 所以会全局阻塞
                GC.Collect();
                for (var i = 0; i < 20; i++) 
                {
                    Thread.Sleep(1000);
                    TwoModel twoModel = new TwoModel();
                }
            
            }

            {
                GC.Collect();
                //DateTime
                string str = "大山";
                // 先分配内存 然后计算
                // 没有享元内存分配  先分配地址内存（预留一部分空间） -然后计算 
                string strs = string.Format("大{0}", "山");
                string de = "大山";
                string des = "大" + "山"; //常量
                Debug.WriteLine(object.ReferenceEquals(str, des));
            }
        }

        public static void ITwoRun()
        {
            {
                //内存泄漏 ： 创建的对象没有被及时回收
                //内存益出 ： 内存不够 数据对象丢失
                //

                //遍历完就清理内存 - 产生不连续内存 - 地址移动 - 修改变量指向 - 所以会全局阻塞
                // 大对象都是 二代回收 没有分代的概念 提升效率  避免内存移动压缩 
                using (SqlConnection da = new SqlConnection()) 
                {

                }
            }
        }
        //析构函数
        ~TwoModel()
        {
            Debug.WriteLine($"123析构{Thread.CurrentThread.ManagedThreadId}");   //CLR 调用  释放GC资源  CLR 线程 队列
            //释放GC资源 CLR肯定调用
            //通常在析构函数内部都是用来做非托管资源释放，因为CLR肯定调用，所以避免使用浙忘记的情况 
        }

        //构造
        public TwoModel() 
        {
            //Debug.WriteLine($"123不是析构{Thread.CurrentThread.ManagedThreadId}");
            //Debug.WriteLine("123析构");
        }
    }
}
