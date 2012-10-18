using System.Collections.Generic;

namespace StringCalculator.DelimiterParser
{
    public class TerminatedDelimiterParser : IDelimiterParser
    {
        public ISet<string> Delimiters { get; private set; }
        public bool HasTerminated { get; private set; }

        internal TerminatedDelimiterParser(ISet<string> delimiters)
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