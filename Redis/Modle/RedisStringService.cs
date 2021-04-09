using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redis.Tool;

namespace Redis.Modle
{
    public class RedisStringService : RedisBase
    {
        //set
        public bool Set<T>(string key, T value) 
        {
            return base.iClient.Set(key,value);
        }

        //set 
        public bool Set<T>(string key, T value, DateTime dt) 
        {
            return base.iClient.Set<T>(key, value, dt);
        }

        public bool Set<T>(string key, T value, TimeSpan timeSpan) 
        {
            
            return base.iClient.Set<T>(key, value, timeSpan);
        }

        public void Set(Dictionary<string, string> dic)
        {
            base.iClient.SetAll(dic);
        }

        public long Append(string key, string value) 
        {
            return base.iClient.AppendToValue(key, value);
        }

        public string GetAndSetValue(string key, string value) 
        {
            return base.iClient.GetAndSetValue(key, value);
        }

        public long incyValue(string key)
        {
            return base.iClient.IncrementValue(key);
        }

        //public long incyValue(string key)
        //{
        //    return base.iClient.Increment(key);
        //}

        public long DecyValue(string key)
        {
            return base.iClient.DecrementValue(key);
        }

        public void StoreAsHash<T>(T obj)
        {
            base.iClient.StoreAsHash(obj);
        }

        public T GetFromHash<T>(object key)
        {
            return base.iClient.GetFromHash<T>(key);
        }

        public object GetAllItemsFromSet(string key) 
        {
            return base.iClient.GetAllItemsFromSet(key);
        }
    }
}
