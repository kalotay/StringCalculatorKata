using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator.Parser
{
    internal static class EnumerableStringExtensions
    {
        public static string NormaliseForRegex(this IEnumerable<string> delimiters)
        {
            var delimitersStrings = delimiters.Select(Regex.Escape)
                .OrderByDescending(s => s.Length);
            return string.Join("|", delimitersStrings);
        }

    }
}