using System.Collections.Generic;

namespace StringCalculator.Parser
{
	public interface IParser
	{
		IEnumerable<int> Parse(string message);
	}
}

