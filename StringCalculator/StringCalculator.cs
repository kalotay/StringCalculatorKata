using System.Collections.Generic;
using System.Text.RegularExpressions;
using StringCalculator.Lexer;
using StringCalculator.Parser;
using StringCalculator.Processor;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        private readonly IProcessor _processor;
        private readonly Regex _defaultSplitter;

        public StringCalculator(IEnumerable<string> defaultDelimiters, IProcessor processor)
        {
            _processor = processor;
            _defaultSplitter = defaultDelimiters.GenerateSplitter();
        }

        public int Add(string message)
        {
            var lexer = new StringCalculatorLexer(message);
            var delimiters = new HashSet<string>();
            string numbersString = null;

            foreach (var token in lexer.Read())
            {
                if (token.Type == StringCalculatorToken.Types.Delimiter)
                {
                    delimiters.Add(token.Content);
                }

                if (token.Type == StringCalculatorToken.Types.Numbers)
                {
                    numbersString = token.Content;
                }
            }

            if (string.IsNullOrEmpty(numbersString))
            {
                return _processor.Process(Enumerable.Empty<int>());
            }

            var numberSplitter = delimiters.Any() ?
                delimiters.GenerateSplitter() :
                _defaultSplitter;

            var numbers = numberSplitter
                .Split(numbersString)
                .Select(int.Parse);

            return _processor.Process(numbers);
        }
    }
}