using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redis.Modle;
using ServiceStack;
using ServiceStack.Redis;

namespace Redis.Tool
{
    public abstract class RedisBase : IDisposable
    {
        //redis 客户端
        public IRedisClient iClient { get; private set; }

        public RedisBase() 
        {
            iClient = RedisManafer.GetClient();  
        }

        ~RedisBase() 
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
    }
}
