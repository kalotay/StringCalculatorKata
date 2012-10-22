using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.Processor
{
    public class MyAdder: IProcessor
    {
        public int Process(IEnumerable<int> numbers)
        {
            return numbers.Sum();
        }
    }
}