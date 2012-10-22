using System.Collections.Generic;

namespace StringCalculator
{
	public interface IParser
	{
		IEnumerable<int> Parse(string message);
	}
}

