using System;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        private readonly string _defaultDelimiters;

        public StringCalculator(string defaultDelimiters = ",\n")
        {
            _defaultDelimiters = defaultDelimiters;
        }

        public int Add(string delimitersAndNumbers)
        {
            if (String.IsNullOrEmpty(delimitersAndNumbers))
            {
                return 0;
            }

            var splitDelimitersAndNumbers = SplitDelimitersAndNumbersWithDefault(delimitersAndNumbers);
            var delimiters = splitDelimitersAndNumbers[0].ToCharArray();
            var numbers = splitDelimitersAndNumbers[1];

            return numbers.Split(delimiters).Sum(number => int.Parse(number));
        }

        private string[] SplitDelimitersAndNumbersWithDefault(string delimitersAndNumbers)
        {
           return delimitersAndNumbers.StartsWith("//")
               ? SplitDelimitersAndNumbers(delimitersAndNumbers)
               : new[] {_defaultDelimiters, delimitersAndNumbers};
        }

        private static string[] SplitDelimitersAndNumbers(string delimitersAndNumbers)
        {
            return delimitersAndNumbers.Substring(2).Split(new[] {'\n'}, 2);
        }
    }
}
