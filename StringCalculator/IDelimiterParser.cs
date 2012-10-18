using System.Collections.Generic;

namespace StringCalculator
{
    public interface IDelimiterParser
    {
        IList<string> Delimiters { get; }
        IDelimiterParser Parent { get; }
        IDelimiterParser Read(char input);
    }
}