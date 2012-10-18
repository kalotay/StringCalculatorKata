using System;
using System.Collections.Generic;

namespace StringCalculator
{
    public class MultiCharacterDelimiterParser: IDelimiterParser
    {
        public readonly IDelimiterParser Parent;
        public IList<string> Delimiters { get; private set; }
        public bool HasTerminated { get; private set; }

        public MultiCharacterDelimiterParser(IDelimiterParser parent)
        {
            Parent = parent;
            HasTerminated = false;
        }

        public IDelimiterParser Read(char input)
        {
            throw new NotImplementedException();
        }
    }
}