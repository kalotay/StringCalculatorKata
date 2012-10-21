using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRegexTests
{
	public class HeaderParser
	{
		private string[] _defaultDelimiters;
		private static readonly Regex _headerRegex = new Regex("//((?<singlechar>[^\n[])|"
			                            + Regex.Escape ("[")
			                            + "(?<multichar>[^]]*)])*\n");


		public HeaderParser(IEnumerable<string> defaultHeader)
		{
			_defaultDelimiters = defaultHeader.ToArray();
		}

		public IEnumerable<string> Parse(string rawMessage)
		{
			var headerMatch = _headerRegex.Match(rawMessage);

			var singleCharDelimiters = headerMatch.Groups["singlechar"].Captures.Cast<Capture>();
			var multiCharDelimiters = headerMatch.Groups["multichar"].Captures.Cast<Capture>();
			var delimiterCaptures = singleCharDelimiters.Concat(multiCharDelimiters);

			var delimiters = delimiterCaptures.Any() ?
				delimiterCaptures.Select(capture => Regex.Escape(capture.Value))
					.OrderByDescending(s => s.Length)
					.ToArray() :
				_defaultDelimiters;

			var body = _headerRegex.Replace(rawMessage, string.Empty);

			var delimitersRegex = new Regex(String.Join("|", delimiters));

			return delimitersRegex.Split(body).AsEnumerable();

		}
	}
}

