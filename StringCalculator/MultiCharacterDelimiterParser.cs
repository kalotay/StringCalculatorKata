using System;
using System.Collections.Generic;

namespace StringCalculator
{
    public class MultiCharacterDelimiterParser: IDelimiterParser
    {
        public IList<string> Delimiters {get; private set ;}
        public bool HasTerminated { get; private set; }

        public readonly IDelimiterParser ParentParser;

        public MultiCharacterDelimiterParser(IDelimiterParser parentParser)
        {
            Delimiters = parentParser.Delimiters;
            HasTerminated = false;
            ParentParser = parentParser;
        }

        public IDelimiterParser Read(char input)
        {
            return (input == ']') ? ParentParser : this;
        }
    }
}