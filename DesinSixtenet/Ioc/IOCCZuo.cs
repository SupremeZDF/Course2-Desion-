using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DesinSixtenet.Ioc
{
    public class IOCCZuo
    {
        private static Dictionary<string, LifeCicleIoc> keyValuePairs = new Dictionary<string, LifeCicleIoc>();
        public void RrgisterType<T, V>(enumLifeCicle enumLifeCicle = enumLifeCicle.Transfrom)
        {
            keyValuePairs.Add(typeof(T).FullName, new LifeCicleIoc() { type = typeof(V), lifeEnum = enumLifeCicle });
        }

        private readonly static object obj = new object();

        private static int io = 0;
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
                var types = keyValuePairs[typeof(T).FullName];
                var obj = default(T);

                switch (type.lifeEnum)
                {
                    case enumLifeCicle.Singlon:
                        if (io == 0)
                        {
                            lock (obj)
                            {
                                if (keyValues.ContainsKey(typeof(T)))
                                {
                                    obj = (T)keyValues[typeof(T)];
                                }
                                else
                                {
                                    obj = (T)ResoveObject(typeof(T));
                                    keyValues.Add(typeof(T), obj);
                                    io++;
                                }
                            }
                        }
                        else 
                        {
                            if (keyValues.ContainsKey(typeof(T)))
                            {
                                obj = (T)keyValues[typeof(T)];
                            }
                        }
                       
                        ; break;
                    case enumLifeCicle.ThreadSinglon:
                        //用线程槽保存 数据保存到线程
                        var oh = CallContext.GetData(typeof(T).FullName);
                        if (oh == null)
                        {
                            obj = (T)ResoveObject(typeof(T));
                            CallContext.SetData(typeof(T).FullName, obj);
                        }
                        else
                        {
                            obj = (T)oh;
                        }

                        ; break;
                    case enumLifeCicle.Transfrom:
                        obj = (T)ResoveObject(typeof(T));
                        ; break;
                }
                return obj;
            }
        }

        public object ResoveObject(Type type)
        {
            //DesinSixtenet.IocExercise   //DesinSixtenet.IocExercise
            var t = keyValuePairs[type.FullName];
            var g = t.type.GetConstructors();
            var f = g.OrderByDescending(s => s.GetParameters().Length).FirstOrDefault();
            //var obj = default(object);
            if (f.GetParameters().Length > 0)
            {
                List<object> list = new List<object>();
                foreach (var para in f.GetParameters())
                {
                    var tt = keyValuePairs[para.ParameterType.FullName];
                    var gg = tt.type;
                    switch (tt.lifeEnum)
                    {
                        case enumLifeCicle.Singlon:
                            if (keyValues.ContainsKey(para.ParameterType))
                            {
                                list.Add(keyValues[para.ParameterType]);
                            }
                            else
                            {
                                var ds = ResoveObject(para.ParameterType);
                                keyValues.Add(para.ParameterType, ds);
                                list.Add(ds);
                            }
                           ; break;
                        case enumLifeCicle.ThreadSinglon:
                            //用线程槽保存 数据保存到线程
                            var oh = CallContext.GetData(para.ParameterType.FullName);
                            if (oh == null)
                            {
                                var ds = ResoveObject(para.ParameterType);
                                CallContext.SetData(para.ParameterType.FullName, ds);
                                list.Add(ds);
                            }
                            else
                            {
                                list.Add(oh);
                            }
                            ; break;
                        case enumLifeCicle.Transfrom:
                            list.Add(ResoveObject(para.ParameterType));
                            ; break;
                    }
                    //var paraType = para.ParameterType;
                    //if (keyValuePairs[para.ParameterType.FullName] != null)
                    //{
                    //    paraType = keyValuePairs[para.ParameterType.FullName].type;
                    //}
                    //var pValue = keyValuePairs[para.ParameterType.FullName];
                    //list.Add(ResoveObject(paraType));
                }
                return Activator.CreateInstance(t.type, list.ToArray());
            }
            else
            {
                return Activator.CreateInstance(t.type);
            }
        }
    }
}
