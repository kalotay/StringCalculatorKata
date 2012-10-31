using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using StringCalculator.Lexer;
using StringCalculator.Lexer.Tokens;

namespace StringCalculator.Parser
{
    class RegexFreeDelimiterParser: IParser
    {
        private readonly Regex _defaultSplitter;

        public RegexFreeDelimiterParser(IEnumerable<string> defaultDelimiters)
        {
            _defaultSplitter = defaultDelimiters.GenerateSplitter();
        }

        public IEnumerable<int> Parse(string message)
        {
            var lexer = new StringCalculatorLexer(message);
            var delimiters = new HashSet<string>();
            string numbersString = null;

            foreach (var token in lexer.Read())
            {
                if (token is DelimiterToken)
                {
                    delimiters.Add(token.Content);
                }

                if (token is NumbersToken)
                {
                    numbersString = token.Content;
                }
            }

            if (string.IsNullOrEmpty(numbersString))
            {
                return Enumerable.Empty<int>();
            }

            var numberSplitter = delimiters.Any() ?
                delimiters.GenerateSplitter() :
                _defaultSplitter;

            return numberSplitter
                .Split(numbersString)
                .Select(int.Parse);
        }
    }
}
