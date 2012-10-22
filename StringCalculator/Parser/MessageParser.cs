using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator.Parser
{
    public class MessageParser : IParser
    {
        private readonly Regex _defaultDelimiters;
        private static readonly Regex DelimitersRegex = new Regex("//(?<delimiters>[^1-9])+\n");

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

            var delimiters = DelimitersRegex.Match(message)
                .Groups["delimiters"]
                .Captures
                .Cast<Capture>()
                .Select(capture => Regex.Escape(capture.Value))
                .ToArray();

            var delimitersSplitter = delimiters.Any()
                                         ? new Regex(string.Join("|", delimiters))
                                         : _defaultDelimiters;

            return delimitersSplitter.Split(numbersString).Select(int.Parse).AsEnumerable();
        }
    }
}