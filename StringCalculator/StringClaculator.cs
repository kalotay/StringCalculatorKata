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

        public int Add(string message)
        {
            if (String.IsNullOrEmpty(message))
            {
                return 0;
            }

            var delimitersAndNumbers = SplitDelimitersAndNumbersWithDefault(message);
            var delimiters = delimitersAndNumbers.Delimiters;
            var numbers = delimitersAndNumbers.Numbers;

            return numbers.Split(delimiters).Sum(number => ParserNumber(number));
        }

        private static int ParserNumber(string number)
        {
            var value = int.Parse(number);
            if (value < 0)
            {
                throw new NegativeNumberException(number);
            }
            return value;
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

    internal class NegativeNumberException : Exception
    {
        public NegativeNumberException(string negativeNumber): base("Received following negative numbers: " + negativeNumber)
        {
        }
    }

    public class DelimitersAndNumbers
    {
        public DelimitersAndNumbers(string delimiters, string numbers)
        {
            Delimiters = delimiters.ToCharArray();
            Numbers = numbers;
        }

        public char [] Delimiters { get; set; }

        public string Numbers { get; set; }
    }
}
