using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Extension;

namespace DesinSixtenet
{
    //[Dependency]
    public interface IocExercise
    {

    }
    public interface InstaceOne
    {

    }

   
    public class A : InstaceOne
    {
        //[InjectionMethod]
        [InjectionConstructor]
        public A(int i)
        {

        }
    }

    public class B : IocExercise
    {
        public B(C c) 
        {

        }
    }

    public class C 
    {
        public C(D d)
        {

        }
    }

    public class D
    {
        public D()
        {

        }
    }
}
