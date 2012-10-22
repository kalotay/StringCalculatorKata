using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.Parser
{
    public class MessageParser : IParser
    {
        public IEnumerable<int> Parse(string message)
        {
            var numbers = string.IsNullOrEmpty(message)
                              ? new int[0].AsEnumerable()
                              : message.Split(',').Select(int.Parse);

            return numbers;
        }
    }
}