using System.Collections.Generic;

namespace StringCalculator
{
    public interface IDelimiterParser
    {
        List<string> Delimiters { get; }
        IDelimiterParser Parent { get; }
        IDelimiterParser Read(char input);
    }
}