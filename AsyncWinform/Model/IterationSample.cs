using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncWinform.Model
{
    public class IterationSample : IEnumerable
    {
        Object[] values;
        Int32 startingPoint;

        //IterationSample

        public IterationSample(Object[] values, Int32 startingPoint)
        {
            this.values = values;
            this.startingPoint = startingPoint;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
