using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisHomeWork.Tool
{
    public abstract class RedisBaseService
    {
        public IRedisClient iClient { get; private set; }

        public RedisBaseService() 
        {
            iClient = RedisFactory.GetClient();
        }

        ~RedisBaseService()
        {
            Dispose(false);
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            //清理托管资源 
            if (disposing)
            {

            }
            //清理非托管资源
            iClient.Dispose();
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            //告诉gc不需要执行析构函数执行垃圾回收
            GC.SuppressFinalize(this);
        }

        public void Tramscation()
        {
            using (IRedisTransaction irt = this.iClient.CreateTransaction())
            {
                try
                {
                    irt.QueueCommand(r => r.Set("key", 20));
                    irt.QueueCommand(r => r.Increment("key", 1));
                    irt.Commit(); // 提交事务
                }
                catch (Exception ex)
                {
                    irt.Rollback();
                    throw ex;
                }
            }
        }

        //
        public virtual void FlushAll()
        {
            iClient.FlushAll();
        }

        //save 
        public void SaveAsync()
        {
            iClient.Save();
        }

        //bgsave
        public void SaveASync()
        {
            iClient.SaveAsync();
        }

        //static RedisBaseService() { }
    }
}
