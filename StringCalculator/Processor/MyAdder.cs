using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.Processor
{
    public class MyAdder: IProcessor
    {
        public int Process(IEnumerable<int> numbers)
        {
            return numbers.Aggregate(0, Add);
        }

        private int Add(int i1, int i2)
        {
            return i2 < 1000
                       ? i1 + i2
                       : i1;
        }
    }
}