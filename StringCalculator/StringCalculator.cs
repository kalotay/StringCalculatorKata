using System;
using System.Collections.Generic;
using System.Linq;
using StringCalculator.Processor;

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


            _negativeNumberException = new NegativeNumberException(new List<int>());

            var result = numbers.Split(delimiters.Select(s => s.First()).ToArray()).Sum(number => ParserNumber(number));
            return result;
        }

        private int ParserNumber(string number)
        {
            var value = int.Parse(number);
            if (value < 0)
            {
            }
            return value < 1000 ? value : 0;
        }
    }
}