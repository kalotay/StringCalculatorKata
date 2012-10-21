using System.Collections.Generic;

namespace StringCalculator
{
	public interface IParser
	{
		IEnumerable<int> Parser(string message);
	}
}

