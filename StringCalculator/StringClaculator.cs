using System;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string delimitersAndNumbers)
        {
            var delimiterSpec = new char[] {',', '\n'};
            var delimiterSpecEnd = -1;

            if (String.IsNullOrEmpty(delimitersAndNumbers))
            {
                return 0;
            }

            if (delimitersAndNumbers.StartsWith("//"))
            {
                delimiterSpecEnd = delimitersAndNumbers.IndexOf('\n');
                delimiterSpec = delimitersAndNumbers.Substring(2, delimiterSpecEnd - 2).ToCharArray();
            }

            var splitNumbers = delimitersAndNumbers.Substring(delimiterSpecEnd + 1).Split(delimiterSpec);

            return splitNumbers.Sum(number => int.Parse(number));
        }
    }
}
