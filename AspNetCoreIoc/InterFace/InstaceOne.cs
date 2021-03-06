using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreIoc.InterFace
{
    public interface InstaceOne
    {

    }

    public class A : InstaceOne
    {
        public A(int i) 
        {
        
        }
    }

    public class B : InstaceOne
    {
        public B()
        {

        }
    }

    public class C : B
    {
        public C()
        {

        }
    }
}
