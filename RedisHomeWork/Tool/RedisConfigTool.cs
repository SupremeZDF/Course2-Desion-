using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisHomeWork.Tool
{
    public class RedisConfigTool
    {

        public string writeServerList = "192.168.107.129,6379";

        public string ReadServerList = "192.168.107.129,6379";

        //最大链接数
        public int maxwritePoolSzie = 1000;

        public int maxreadPoolSize = 1000;

        public int localCacheTimre = 1000;

        public bool AutoStart = true;

        public bool RecordeLog = false;
    }
}
