using System.Collections.Generic;

namespace StringCalculator
{
    public class DelimiterParserDriver
    {
        private DelimiterParser.IDelimiterParser _delimiterParser;

        public DelimiterParserDriver(DelimiterParser.IDelimiterParser delimiterParser)
        {
            _delimiterParser = delimiterParser;
            Delimiters = delimiterParser.Delimiters;
        }

        public ISet<string> Delimiters { get; private set; }

        public bool Read(char c)
        {
            _delimiterParser = _delimiterParser.Read(c);
            return !_delimiterParser.HasTerminated;
        }
    }
}