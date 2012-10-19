using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        private readonly string[] _defaultDelimiters;
        private NegativeNumberException _negativeNumberException;

        public StringCalculator(ISet<string> defaultDelimiters)
        {
            _defaultDelimiters = defaultDelimiters.ToArray();
        }

        public StringCalculator(): this(new HashSet<string>{",", "\n"})
        {}

        public int Add(string message)
        {
            if (String.IsNullOrEmpty(message))
            {
                return 0;
            }

            var delimiters = _defaultDelimiters;
            var numbers = message;

            if (message.StartsWith("//"))
            {
                var delimiterParserDriver = new DelimiterParserDriver(new DelimiterParser.DelimiterParser());
                numbers = message.Substring(2);
                
                while (delimiterParserDriver.Read(numbers.First()))
                {
                    numbers = numbers.Substring(1);
                }
                delimiters = delimiterParserDriver.Delimiters.ToArray();
            }

            _negativeNumberException = new NegativeNumberException();

            var result = numbers.Split(delimiters.Select(s => s.First()).ToArray()).Sum(number => ParserNumber(number));
            if (!_negativeNumberException.IsEmpty())
            {
                throw _negativeNumberException;
            }
            return result;
        }

        private int ParserNumber(string number)
        {
            var value = int.Parse(number);
            if (value < 0)
            {
                _negativeNumberException.Add(number);
            }
            return value < 1000 ? value : 0;
        }

        private static DelimitersAndNumbers SplitDelimitersAndNumbers(string delimitersAndNumbers)
        {
            var splitDelimitersAndNumbers = delimitersAndNumbers.Substring(2).Split(new[] {'\n'}, 2);
            return new DelimitersAndNumbers(splitDelimitersAndNumbers[0], splitDelimitersAndNumbers[1]);
        }
    }

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