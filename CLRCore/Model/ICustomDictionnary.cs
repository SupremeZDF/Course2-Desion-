using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRCore.Model
{
    public class ICustomDictionnary
    {
        //第三方 数据存储和获取地方
        // private 安全
        //字典读取速率高


        //缓存优化性能 核心就是 结果重用 下一次请求还是用上一次的结果
        //如果数据有变化呢 用的是一个错误的数据
        //会有脏数据

        //数据更新单条缓存 常规做法是Remove 掉 不是更新
        //缓存提升效率 不是保存数据
        public static void IOneRun() 
        {
        
        }

        //菜单 删除 
        //缓存更新
        //删除部分数据 删除受影响的数据
        public static void ITwoRun()
        {
        
        }

        //第三方删除了数据 缓存并不知道 这个没办法
        //可以调用接口清理缓存  系统修改数据 调用c系统通知下缓存更新
        //就只能容忍了 容忍脏数据  （可以加上时间限制，减少影响时间）
        
        //过期策略
        //永久有效 -- 目前就是
        //绝对过期 -- 有个时间点 超过就过期
        //滑动过期 -- 多久之后过期 滑动过期 如果期间更新/查询 ，就再次延长
        public static void IThreeRun() 
        {
            //TimeSpan
        }

        //主动清理 加 被动清理 不会让缓存数据滞留太久
        public static void IFoureRun()
        {
            //TimeSpan
            //Task.Run(() => { }, 10);
        }

        //ConcurrentDictionary 线程安全容易
        public static void IFiveRun() 
        {
            ConcurrentDictionary<string,object> keyValuePairs = new System.Collections.Concurrent.ConcurrentDictionary<string, object>();

            var str = "123";
            var t = str.GetHashCode();
            new object().GetHashCode();

            Dictionary<string, string> keyValuePairs1 = new Dictionary<string, string>();
            keyValuePairs1.Add(str, "123");
            //keyValuePairs1.Add(str, "123");
            //int 
        }

        //缓存用在那里  满足那些特点 适合用缓存 
        //访问频繁+耗时耗资源+相对稳定+体积不那么大
        public static void ISixRun()
        {
        
        }
    }
}
