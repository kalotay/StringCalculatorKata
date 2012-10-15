using System;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        private readonly string _defaultDelimiters;
        private NegativeNumberException _negativeNumberException;

        public StringCalculator(string defaultDelimiters = ",\n")
        {
            _defaultDelimiters = defaultDelimiters;
        }

        public int Add(string message)
        {
            if (String.IsNullOrEmpty(message))
            {
                return 0;
            }

            var delimitersAndNumbers = SplitDelimitersAndNumbersWithDefault(message);
            var delimiters = delimitersAndNumbers.Delimiters;
            var numbers = delimitersAndNumbers.Numbers;
            _negativeNumberException = new NegativeNumberException();

            var result = numbers.Split(delimiters).Sum(number => ParserNumber(number));
            if (!_negativeNumberException.IsEmpty())
            {
                throw _negativeNumberException;
            }
            return result;
        }

        private int ParserNumber(string number)
        {
            var value = int.Parse(number);
            if (value < 0)
            {
                _negativeNumberException.Add(number);
            }
            return value < 1000 ? value : 0;
        }

        private DelimitersAndNumbers SplitDelimitersAndNumbersWithDefault(string delimitersAndNumbers)
        {
            return delimitersAndNumbers.StartsWith("//")
                       ? SplitDelimitersAndNumbers(delimitersAndNumbers)
                       : new DelimitersAndNumbers(_defaultDelimiters, delimitersAndNumbers);
        }

        private static DelimitersAndNumbers SplitDelimitersAndNumbers(string delimitersAndNumbers)
        {
            var splitDelimitersAndNumbers = delimitersAndNumbers.Substring(2).Split(new[] {'\n'}, 2);
            return new DelimitersAndNumbers(splitDelimitersAndNumbers[0], splitDelimitersAndNumbers[1]);
        }
    }
}