using System;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string delimitersAndNumbers)
        {
            if (String.IsNullOrEmpty(delimitersAndNumbers))
            {
                return 0;
            }

            var splitDelimitersAndNumbers = SplitDelimitersAndNumbers(delimitersAndNumbers);
            var delimiters = splitDelimitersAndNumbers[0].ToCharArray();
            var numbers = splitDelimitersAndNumbers[1];

            return numbers.Split(delimiters).Sum(number => int.Parse(number));
        }

        private static string[] SplitDelimitersAndNumbers(string delimitersAndNumbers)
        {
            var splitDelimitersAndNumbers = delimitersAndNumbers.StartsWith("//")
                                                ? delimitersAndNumbers.Substring(2).Split(new[] {'\n'}, 2)
                                                : new[] {",\n", delimitersAndNumbers};
            return splitDelimitersAndNumbers;
        }
    }
}
