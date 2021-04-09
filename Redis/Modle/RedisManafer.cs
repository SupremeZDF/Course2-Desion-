using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redis.Tool;
using ServiceStack.Redis;
using System.Threading;

namespace Redis.Modle
{
    public class RedisManafer
    {
        private static RedisConfigInfo RedisConfigInfo = new RedisConfigInfo();

        private static PooledRedisClientManager prcManager;

        private static RedisClient RedisClient;

        static RedisManafer()
        {
            CreatManager();
        }

        //创建链接池管理对象 
        private static void CreatManager() 
        {
            string[] sriteServerConfig = RedisConfigInfo.writeServerList.Split(',');
            string [] readServerConstr = RedisConfigInfo.ReadServerList.Split(',');
            //prcManager.Dispose();
            RedisClient = new RedisClient(sriteServerConfig[0], 82);
            //RedisClient.Password = "123456";
            //RedisClient.Password = "123456";
            prcManager = new PooledRedisClientManager(sriteServerConfig, readServerConstr,new RedisClientManagerConfig()
            {
                  MaxWritePoolSize = RedisConfigInfo.maxwritePoolSzie,
                  MaxReadPoolSize = RedisConfigInfo.maxreadPoolSize,
                  AutoStart = RedisConfigInfo.AutoStart
            });

        }
        public static int ii = 0;
        public static IRedisClient GetClient() 
        {
            //ii++;
            string[] sriteServerConfig = RedisConfigInfo.writeServerList.Split(',');
            string[] readServerConstr = RedisConfigInfo.ReadServerList.Split(',');
            //prcManager.Dispose();
            return new RedisClient(sriteServerConfig[0], 6379);
            //ThreadLocal threadLocal = new System.Threading.ThreadLocal();
            //prcManager
            //return prcManager.GetClient();
            //return RedisClient;
        }
    }
}
