using System.Collections.Generic;

namespace StringCalculator.Processor
{
	public interface IProcessor
	{
		int Process(IEnumerable<int> numbers);
	}
}

