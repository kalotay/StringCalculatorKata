using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.Parser
{
    public class MessageParser : IParser
    {
        private char[] _defaultDelimiters = new [] {',', '\n'};

        public IEnumerable<int> Parse(string message)
        {
            _defaultDelimiters = new[] {',', '\n'};
            var numbers = string.IsNullOrEmpty(message)
                              ? new int[0].AsEnumerable()
                              : message.Split(_defaultDelimiters).Select(int.Parse);

            return numbers;
        }
    }
}