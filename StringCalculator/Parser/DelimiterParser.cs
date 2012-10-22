using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator.Parser
{
    public class DelimiterParser : IParser
    {
        private static readonly Regex DelimitersRegex = new Regex("//" //starts with "//"
            + "(" //then match...
                + "(?<singlechar>[^0-9\n[])" //a single character delimiter (anything but digits, "[" and newlines)
                + "|" //or
                + Regex.Escape("[")
                    + "(?<multichar>[^]0-9]+)" //a multicharacter delimiter (anything but digits and "]" at least once)
                + "]"
            +")+" //...at least once
            + "\n"); //end with newline

        private readonly Regex _defaultDelimiters;

        public DelimiterParser(IEnumerable<string> defaultDelimiters)
        {
            var regexString = string.Join("|", defaultDelimiters.NormaliseForRegex());
            _defaultDelimiters = new Regex(regexString);
        }

        public IEnumerable<int> Parse(string message)
        {
            var numbersString = DelimitersRegex.Replace(message, string.Empty);

            if (string.IsNullOrEmpty(numbersString))
            {
                return new int[0].AsEnumerable();
            }

            return GetDelimitersSplitter(message)
                .Split(numbersString)
                .Select(int.Parse)
                .AsEnumerable();
        }

        private Regex GetDelimitersSplitter(string message)
        {
            var delimiterGroups = DelimitersRegex.Match(message)
                .Groups;
            var singleCharDelimiters = delimiterGroups["singlechar"];
            var multiCharDelimiters = delimiterGroups["multichar"];

            if ((singleCharDelimiters.Length + multiCharDelimiters.Length) < 1)
            {
                return _defaultDelimiters;
            }

            var delimiters = singleCharDelimiters.Captures.Cast<Capture>()
                .Concat(multiCharDelimiters.Captures.Cast<Capture>())
                .Select(capture => capture.Value)
                .NormaliseForRegex();

            var delimitersPattern = string.Join("|", delimiters);
            return new Regex(delimitersPattern);
        }
    }
}