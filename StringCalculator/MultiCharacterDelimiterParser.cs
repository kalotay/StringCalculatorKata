using System.Collections.Generic;
using System.Text;

namespace StringCalculator
{
    public class MultiCharacterDelimiterParser: IDelimiterParser
    {
        public IList<string> Delimiters {get; private set ;}
        public bool HasTerminated { get; private set; }

        public readonly IDelimiterParser ParentParser;

        private readonly StringBuilder _multiCharDelimiter;

        public MultiCharacterDelimiterParser(IDelimiterParser parentParser)
        {
            Delimiters = parentParser.Delimiters;
            HasTerminated = false;
            ParentParser = parentParser;
            _multiCharDelimiter = new StringBuilder();
        }

        public IDelimiterParser Read(char input)
        {
            if (input == ']')
            {
                Delimiters.Add(_multiCharDelimiter.ToString());
                return ParentParser;
            }

            _multiCharDelimiter.Append(input);
            return this;
        }
    }
}