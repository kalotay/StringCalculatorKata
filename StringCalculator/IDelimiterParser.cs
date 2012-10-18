using System.Collections.Generic;

namespace StringCalculator
{
    public interface IDelimiterParser
    {
        IList<string> Delimiters { get; }
        bool HasTerminated { get; }
        IDelimiterParser Read(char input);
    }
}