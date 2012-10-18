using System.Collections.Generic;

namespace StringCalculator
{
    public class DelimiterParser: IDelimiterParser
    {
        public IList<string> Delimiters { get; private set; }
        public IDelimiterParser Parent { get; private set; }
        public bool HasTerminated { get; private set; }

        public DelimiterParser()
        {
            Delimiters = new List<string>();
            Parent = null;
            HasTerminated = false;
        }

        public IDelimiterParser Read(char input)
        {
            if (input == '\n')
            {
                HasTerminated = true;
            }
            else
            {
                Delimiters.Add(input.ToString());
            }
            return this;
        }
    }
}