using System;
using System.Collections.Generic;

namespace StringCalculator
{
    public class MultiCharacterDelimiterParser: IDelimiterParser
    {
        public readonly IDelimiterParser ParentParser;
        public IList<string> Delimiters { get; private set; }
        public bool HasTerminated { get; private set; }

        public MultiCharacterDelimiterParser(IDelimiterParser parentParser)
        {
            ParentParser = parentParser;
            HasTerminated = false;
        }

        public IDelimiterParser Read(char input)
        {
            throw new NotImplementedException();
        }
    }
}