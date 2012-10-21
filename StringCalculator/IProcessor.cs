using System.Collections.Generic;

namespace StringCalculator
{
	public interface IProcessor
	{
		int Process(IEnumerable<int> numbers);
	}
}

