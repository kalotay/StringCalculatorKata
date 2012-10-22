using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator.Parser
{
    public class MessageParser : IParser
    {
        private readonly char[] _defaultDelimiters = new [] {',', '\n'};

        public MessageParser(char[] defaultDelimiters)
        {
            _defaultDelimiters = defaultDelimiters;
        }

        public IEnumerable<int> Parse(string message)
        {
            var delimitersRegex = new Regex("//(?<delimiters>[^1-9])+\n");
            var numbersString = delimitersRegex.Replace(message, string.Empty);

            if (string.IsNullOrEmpty(numbersString))
            {
                return new int[0].AsEnumerable();
            }

            var delimiters = delimitersRegex.Match(message)
                .Groups["delimiters"]
                .Captures
                .Cast<Capture>()
                .Select(capture => Regex.Escape(capture.Value));

            var delimiterRegexString = delimiters.Any()
                              ? string.Join("|", delimiters)
                              : string.Join("|", _defaultDelimiters);

            var delimitersSplitter = new Regex(delimiterRegexString);

            return delimitersSplitter.Split(numbersString).Select(int.Parse).AsEnumerable();
        }
    }
}