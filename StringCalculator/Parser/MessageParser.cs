using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator.Parser
{
    public class MessageParser : IParser
    {
        private readonly Regex _defaultDelimiters;

        public MessageParser(IEnumerable<string> defaultDelimiters)
        {
            var regexString = string.Join("|", defaultDelimiters.Select(Regex.Escape));
            _defaultDelimiters = new Regex(regexString);
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

            var delimitersSplitter = delimiters.Any()
                                         ? new Regex(string.Join("|", delimiters))
                                         : _defaultDelimiters;

            return delimitersSplitter.Split(numbersString).Select(int.Parse).AsEnumerable();
        }
    }
}