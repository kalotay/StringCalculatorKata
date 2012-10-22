using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator.Parser
{
    public class MessageParser : IParser
    {
        private readonly Regex _defaultDelimiters;
        private static readonly Regex DelimitersRegex = new Regex("//((?<singlechar>[^0-9\n[])|"
            + Regex.Escape("[")
            + "(?<multichar>[^0-9]+)])+\n");

        public MessageParser(IEnumerable<string> defaultDelimiters)
        {
            var regexString = string.Join("|", defaultDelimiters.Select(Regex.Escape));
            _defaultDelimiters = new Regex(regexString);
        }

        public IEnumerable<int> Parse(string message)
        {
            var numbersString = DelimitersRegex.Replace(message, string.Empty);

            if (string.IsNullOrEmpty(numbersString))
            {
                return new int[0].AsEnumerable();
            }

            var delimitersSplitter = GetDelimitersSplitter(message);

            return delimitersSplitter.Split(numbersString)
                .Select(int.Parse)
                .AsEnumerable();
        }

        private Regex GetDelimitersSplitter(string message)
        {
            var singleCharDelimiters = DelimitersRegex.Match(message)
                .Groups["singlechar"];

            var multiCharDelimiters = DelimitersRegex.Match(message)
                .Groups["multichar"];

            var delimitersGroups = singleCharDelimiters.Captures.Cast<Capture>()
                .Concat(multiCharDelimiters.Captures.Cast<Capture>())
                .ToArray();

            if (!delimitersGroups.Any())
            {
                return _defaultDelimiters;
            }


            var delimiters = delimitersGroups
                .Select(capture => Regex.Escape(capture.Value))
                .ToArray();

            return new Regex(string.Join("|", delimiters));
        }
    }
}