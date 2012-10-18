using System.Collections.Generic;

namespace StringCalculator
{
    public class TerminatedDelimiterParser : IDelimiterParser
    {
        public IList<string> Delimiters { get; private set; }
        public bool HasTerminated { get; private set; }

        public TerminatedDelimiterParser(IList<string> delimiters)
        {
            Delimiters = delimiters;
            HasTerminated = true;
        }

        public IDelimiterParser Read(char input)
        {
            throw new ParserTerminatedException();
        }
    }
}