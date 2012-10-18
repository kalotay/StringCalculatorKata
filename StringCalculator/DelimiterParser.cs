using System.Collections.Generic;

namespace StringCalculator
{
    public class DelimiterParser: IDelimiterParser
    {
        public IList<string> Delimiters { get; private set; }
        public bool HasTerminated { get; private set; }

        public DelimiterParser()
        {
            Delimiters = new List<string>();
            HasTerminated = false;
        }

        public IDelimiterParser Read(char input)
        {
            if (input == '\n')
            {
                return new TerminatedDelimiterParser(Delimiters);
            }

            if (input == '[')
            {
                return new MultiCharacterDelimiterParser(this);
            }

            Delimiters.Add(input.ToString());
            return this;
        }
    }

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