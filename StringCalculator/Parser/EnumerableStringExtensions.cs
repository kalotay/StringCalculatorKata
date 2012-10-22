using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator.Parser
{
    internal static class EnumerableStringExtensions
    {
        public static IEnumerable<string> NormaliseForRegex(this IEnumerable<string> delimiters)
        {
            return delimiters.Select(Regex.Escape)
                .OrderByDescending(s => s.Length);
        }

    }
}