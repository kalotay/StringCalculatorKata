using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator.Parser
{
    public class DelimiterParser : IParser
    {
        private static readonly Regex DelimitersRegex = new Regex(
            //starts with "//"
            "//"
            //then match...
            + "("
                //a single character delimiter (anything but digits, "[" and newlines)
                + "(?<singlechar>[^0-9\n[])"
                //or
                + "|"
                //if there is a "["
                + Regex.Escape("[")
                    //a multicharacter delimiter (anything but digits and "]" at least once)
                    + "(?<multichar>[^]0-9]+)"
                //until "]"
                + "]"
            //...at least once
            +")+"
            //end with newline
            + "\n"
        );

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
            var singleCharDelimiterGroup = delimiterGroups["singlechar"];
            var multiCharDelimiterGroup = delimiterGroups["multichar"];

            if ((singleCharDelimiterGroup.Length + multiCharDelimiterGroup.Length) < 1)
            {
                return _defaultDelimiters;
            }

            var singleCharDelimiterCaptures = singleCharDelimiterGroup.Captures.OfType<Capture>();
            var multiCharDelimiterCaptures = multiCharDelimiterGroup.Captures.OfType<Capture>();

            var delimiters = singleCharDelimiterCaptures
                .Concat(multiCharDelimiterCaptures)
                .Select(capture => capture.Value)
                .NormaliseForRegex();

            var delimitersPattern = string.Join("|", delimiters);
            return new Regex(delimitersPattern);
        }
    }
}