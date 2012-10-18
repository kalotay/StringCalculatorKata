using System;
using System.Collections.Generic;

namespace StringCalculator
{
    public class MultiCharacterDelimiterParser: IDelimiterParser
    {
        public readonly IDelimiterParser Parent;

        public MultiCharacterDelimiterParser(IDelimiterParser parent)
        {
            Parent = parent;
        }

        public IList<string> Delimiters { get; private set; }
        public bool HasTerminated { get; private set; }
        public IDelimiterParser Read(char input)
        {
            throw new NotImplementedException();
        }
    }
}