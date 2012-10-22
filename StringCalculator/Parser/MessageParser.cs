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
            + "(?<multichar>[^]0-9]+)])+\n");

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

            return GetDelimitersSplitter(message)
                .Split(numbersString)
                .Select(int.Parse)
                .AsEnumerable();
        }

        private Regex GetDelimitersSplitter(string message)
        {
            var singleCharDelimiters = GetDelimitersGroup(message, "singlechar");

            var multiCharDelimiters = GetDelimitersGroup(message, "multichar");

            if ((singleCharDelimiters.Length + multiCharDelimiters.Length) < 1)
            {
                return _defaultDelimiters;
            }

            var delimiters = singleCharDelimiters.Captures.Cast<Capture>()
                .Concat(multiCharDelimiters.Captures.Cast<Capture>())
                .Select(capture => Regex.Escape(capture.Value))
                .OrderByDescending(s => s.Length)
                .ToArray();

            return new Regex(string.Join("|", delimiters));
        }

        private static Group GetDelimitersGroup(string message, string type)
        {
            return DelimitersRegex.Match(message)
                .Groups[type];
        }
    }
}