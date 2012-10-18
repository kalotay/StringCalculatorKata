using System.Collections.Generic;

namespace StringCalculator.DelimiterParser
{
    public interface IDelimiterParser
    {
        ISet<string> Delimiters { get; }
        bool HasTerminated { get; }
        IDelimiterParser Read(char input);
    }
}