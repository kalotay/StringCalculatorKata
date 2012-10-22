using System.Collections.Generic;
using System.Linq;

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
            var numbers = string.IsNullOrEmpty(message)
                              ? new int[0].AsEnumerable()
                              : message.Split(_defaultDelimiters).Select(int.Parse);

            return numbers;
        }
    }
}