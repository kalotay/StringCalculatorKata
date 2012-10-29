using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator.Parser
{
    internal static class RegexNormalisationExtension
    {
        public static Regex GenerateSplitter(this IEnumerable<string> tokens)
        {
            var orderedEscapedTokens = tokens.Select(Regex.Escape)
                .OrderByDescending(s => s.Length);
            var regexSpec = string.Join("|", orderedEscapedTokens);
            return new Regex(regexSpec);
        }

    }
}