using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisHomeWork.Tool
{
    public class RedisFactory
    {
        private static RedisConfigTool RedisConfigInfo = new RedisConfigTool();

        private static PooledRedisClientManager prcManager;

        private static RedisClient RedisClient;

        static RedisFactory()
        {
            CreatManager();
        }

        //创建链接池管理对象 
        private static void CreatManager()
        {
            string[] sriteServerConfig = RedisConfigInfo.writeServerList.Split(',');
            string[] readServerConstr = RedisConfigInfo.ReadServerList.Split(',');

            //prcManager.Dispose();
            //RedisClient = new RedisClient(sriteServerConfig[0], 82);
            //RedisClient.Password = "123456";
            //RedisClient.Password = "123456";

            prcManager = new PooledRedisClientManager(sriteServerConfig, readServerConstr, new RedisClientManagerConfig()
            {
                MaxWritePoolSize = RedisConfigInfo.maxwritePoolSzie,
                MaxReadPoolSize = RedisConfigInfo.maxreadPoolSize,
                AutoStart = RedisConfigInfo.AutoStart
            });

            RedisClient = new RedisClient(sriteServerConfig[0], 6379);
        }
        //public static int ii = 0;
        public static IRedisClient GetClient()
        {
            //string[] sriteServerConfig = RedisConfigInfo.writeServerList.Split(',');
            //string[] readServerConstr = RedisConfigInfo.ReadServerList.Split(',');
            return RedisClient;
            //prcManager.Dispose();
            //ThreadLocal threadLocal = new System.Threading.ThreadLocal();
            //prcManager
            //return prcManager.GetClient();
            //return RedisClient;
        }
    }
}
