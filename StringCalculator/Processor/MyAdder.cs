using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.Processor
{
    public class MyAdder: IProcessor
    {
        private IList<int> _negativeNumbers;

        public int Process(IEnumerable<int> numbers)
        {
            var sum = SumUp(numbers);

            CheckForNegatives();

            return sum;
        }

        private int SumUp(IEnumerable<int> numbers)
        {
            _negativeNumbers = new List<int>();
            return numbers.Aggregate(0, Add);
        }

        private void CheckForNegatives()
        {
            if (_negativeNumbers.Any())
            {
                throw new NegativeNumberException(_negativeNumbers);
            }
        }

        private int Add(int accumulator, int next)
        {
            if (next < 0)
            {
                _negativeNumbers.Add(next);
                return accumulator;
            }

            return next < 1000
                       ? accumulator + next
                       : accumulator;
        }
    }
}