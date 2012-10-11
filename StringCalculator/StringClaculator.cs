using System;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string delimitersAndNumbers)
        {
            var delimiterSpec = new[] {',', '\n'};
            var numbers = delimitersAndNumbers;

            if (String.IsNullOrEmpty(delimitersAndNumbers))
            {
                return 0;
            }

            if (delimitersAndNumbers.StartsWith("//"))
            {
                var tokens = delimitersAndNumbers.Substring(2).Split(new[] {'\n'}, 2);
                delimiterSpec = tokens[0].ToCharArray();
                numbers = tokens[1];
            }

            return numbers.Split(delimiterSpec).Sum(number => int.Parse(number));
        }
    }
}
