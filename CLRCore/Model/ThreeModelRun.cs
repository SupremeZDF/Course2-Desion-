using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;

namespace CLRCore.Model
{
    public class ThreeModelRun : IDisposable
    {
        // 析构函数 ： 被动清理
        // Dispose ：  主动清理
        //托管资源
        private Name GetName = new Name();
        //非托管资源
        private Name name = new Name();

        private bool bls = false;

        public void Dispose()
        {
            //throw new NotImplementedException();
            this.Dispose(true);
            //这是告诉CLR，在进行垃圾回收的时候，不用再继续调用析构方法（终结器）了。是的，
            //因为你已经手动释放资源了。这也从另一个方面验证了析构方法只是作为资源释放的补救机制。
            //因为假设你忘记Close或者Dispose了，CLR会在垃圾回收的时候为你做这件事。
            Debug.WriteLine("非析构函数 清理缓存");
            GC.SuppressFinalize(this);  //
        }

        public ThreeModelRun() 
        {
        
        }

        //析构函数
        ~ThreeModelRun()
        {
            Debug.WriteLine("析构函数 清理缓存");
            //补救措施 在调用者未调用dispose方法的一个补救措施 交给 clr 垃圾回收机制执行 
            this.Dispose(false);
        }

        protected virtual void Dispose(bool bl)
        {
            //using (SqlConnection sql = new SqlConnection()) 
            //{

            //}
            //避免重复清理资源
            if (bls) //判断已经回收的不用在垃圾回收了
            {
                return;
            }
            //清理托管资源
            if (bl) 
            {
                if (GetName != null)
                {
                    GetName = null;
                }
            }
            //清理非托管资源
            if (name != null) 
            {
                name = null;
            }
            bls = true;
        }

        //告诉调用者 垃圾回收了 就不用回收了
        public void SamplePublicMethod()
        {
            if (bls)
            {
                throw new ObjectDisposedException("SampleClass", "SampleClass is disposed");
            }
            //后续操作
        }

        public void IOneRunModel()
        {

        }

    }

    public class Name
    {

    }
}
