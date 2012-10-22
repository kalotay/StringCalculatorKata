using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.Parser
{
    public class MessageParser : IParser
    {
        public IEnumerable<int> Parse(string message)
        {
            return (new int[0]).AsEnumerable();
        }
    }
}