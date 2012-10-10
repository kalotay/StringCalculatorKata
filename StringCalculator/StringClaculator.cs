using System;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (String.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var splitNumbers = numbers.Split(',');

            return splitNumbers.Sum(number => int.Parse(number));
        }
    }
}
