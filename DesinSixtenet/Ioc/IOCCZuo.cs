using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesinSixtenet.Ioc
{
    public class IOCCZuo
    {
        private static Dictionary<string, LifeCicleIoc> keyValuePairs = new Dictionary<string, LifeCicleIoc>();
        public void RrgisterType<T, V>(enumLifeCicle enumLifeCicle = enumLifeCicle.Transfrom)
        {
            keyValuePairs.Add(typeof(T).FullName,new LifeCicleIoc() {type = typeof(V),lifeEnum = enumLifeCicle });
        }

       //单列
        private Dictionary<Type, object> keyValues = new Dictionary<Type, object>();

        public T Resove<T>() 
        {
            {
                //var t = keyValuePairs[typeof(T).FullName];
                //var g = t.GetConstructors();
                //var f = g.OrderByDescending(s => s.GetParameters().Length).FirstOrDefault();
                //if (f.GetParameters().Length > 0)
                //{
                //    List<object> list = new List<object>();
                //    foreach (var para in f.GetParameters())
                //    {
                //        //var pValue = keyValuePairs[para.ParameterType.FullName];
                //        list.Add(ResoveObject(para.ParameterType));
                //    }
                //    return (T)Activator.CreateInstance(t, list.ToArray());
                //}
                //else
                //{
                //    return (T)Activator.CreateInstance(t);
                //}
            }
            {
                var type = keyValuePairs[typeof(T).FullName];

                var obj = default(T);

                switch (type.lifeEnum) 
                {
                    case enumLifeCicle.Singlon:
                        if (keyValues.ContainsKey(typeof(T)))
                            { }
                        ; break;
                    case enumLifeCicle.ThreadSinglon:

                        ; break;
                    case enumLifeCicle.Transfrom:
                        obj = (T)ResoveObject(type.type);
                        ; break;
                }
                return obj;
            }
        }

        //
        public object ResoveObject(Type type) 
        {
            //var t = keyValuePairs[type.GetType().FullName];
            var g = type.GetConstructors();
            var f = g.OrderByDescending(s => s.GetParameters().Length).FirstOrDefault();
            if (f.GetParameters().Length > 0)
            {
                List<object> list = new List<object>();
                foreach (var para in f.GetParameters())
                {
                    var paraType = para.ParameterType;
                    if (keyValuePairs[para.ParameterType.FullName] != null) 
                    {
                        paraType = keyValuePairs[para.ParameterType.FullName].type;
                    }
                    //var pValue = keyValuePairs[para.ParameterType.FullName];
                    list.Add(ResoveObject(paraType));
                }
                return Activator.CreateInstance(type, list.ToArray());
            }
            else
            {
                return Activator.CreateInstance(type);
            }
        }
    }
}
