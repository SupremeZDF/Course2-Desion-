using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesinSixtenet.Ioc
{
    public class LifeCicleIoc
    {
        public Type type;

        public enumLifeCicle lifeEnum;
    }

    public enum enumLifeCicle 
    {
         Transfrom,
         Singlon,
         ThreadSinglon
    }
}
