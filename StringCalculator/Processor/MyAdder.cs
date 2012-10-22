using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.Processor
{
    public class MyAdder: IProcessor
    {
        private IList<int> _negativeNumbers;

        public int Process(IEnumerable<int> numbers)
        {
            _negativeNumbers = new List<int>();
            var sum = numbers.Aggregate(0, Add);

            if (_negativeNumbers.Any())
            {
                throw new NegativeNumberException(_negativeNumbers);
            }

            return sum;
        }

        private int Add(int i1, int i2)
        {
            if (i2 < 0)
            {
                _negativeNumbers.Add(i2);
                return i1;
            }

            return i2 < 1000
                       ? i1 + i2
                       : i1;
        }
    }
}