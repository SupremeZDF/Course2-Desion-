using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRCore.OneRun
{
    public class OneCacheRun
    {
        // 分片保存缓存数据 提高缓存性能
        private static List<Dictionary<string, object>> keyValuePairs = new List<Dictionary<string, object>>(); //缓存数据容器

        private static List<object> List = new List<object>(); // 不同容器对应不同的锁
        
        private static int fpContainer =0; // 容器数量
        
        //初始化容器 减少容器的影响范围
        static OneCacheRun() 
        {
            fpContainer = 3;
            for (var i = 0; i < fpContainer; i++) 
            {
                keyValuePairs.Add(new Dictionary<string, object>());
                List.Add(new object());
            }
        }

        /// <summary>
        /// 访问数据 
        /// </summary>
        public static void FWData(string key) 
        {
            var hashCode = key.GetHashCode();
            //获取key相对应的容器
            var cg = hashCode % 3;
        }
    }

    public class ModelDate 
    {
        //过期策略
        //永久有效 -- 目前就是
        //绝对过期 -- 有个时间点 超过就过期
        //滑动过期 -- 多久之后过期 滑动过期 如果期间更新/查询 ，就再次延长
        public object Value { get; set; }
        
        //过期时间
        public DateTime DeadLine { get; set; }

        //滑动过期时间间隔
        public TimeSpan TimeSpan { get; set; }

        //缓存数据过期机制
        public CacheType cacheType { get; set; }
    }

    public enum CacheType 
    {
        Never ,  //永久有效
        Absolote,   //一段时间有效
        Relative   // 滑动过期
    }
}
