using System.Collections.Generic;

namespace StringCalculator
{
    public class DelimiterParser: IDelimiterParser
    {
        public List<string> Delimiters { get; private set; }
        public IDelimiterParser Parent { get; private set; }

        public DelimiterParser()
        {
            Delimiters = new List<string>();
            Parent = null;
        }

        public IDelimiterParser Read(char input)
        {
            return this;
        }
    }
}