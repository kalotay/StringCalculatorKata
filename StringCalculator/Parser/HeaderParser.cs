using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator.Parser
{
    public class HeaderParser : IParser
    {
        private readonly string[] _defaultDelimiters;

        private static readonly Regex HeaderRegex = new Regex("//((?<singlechar>[^\n[])|"
                                                              + Regex.Escape("[")
                                                              + "(?<multichar>[^]]*)])*\n");


        public HeaderParser(IEnumerable<string> defaultHeader)
        {
            _defaultDelimiters = defaultHeader.ToArray();
        }

        public IEnumerable<int> Parse(string rawMessage)
        {
            var headerMatch = HeaderRegex.Match(rawMessage);

            var singleCharDelimiters = headerMatch.Groups["singlechar"].Captures.Cast<Capture>();
            var multiCharDelimiters = headerMatch.Groups["multichar"].Captures.Cast<Capture>();
            var delimiterCaptures = singleCharDelimiters.Concat(multiCharDelimiters);

            var delimiters = delimiterCaptures.Any()
                                 ? delimiterCaptures.Select(capture => Regex.Escape(capture.Value))
                                       .OrderByDescending(s => s.Length)
                                       .ToArray()
                                 : _defaultDelimiters;

            var body = HeaderRegex.Replace(rawMessage, string.Empty);

            var delimitersRegex = new Regex(String.Join("|", delimiters));

            return delimitersRegex.Split(body).Select(int.Parse).AsEnumerable();

        }
    }

}

