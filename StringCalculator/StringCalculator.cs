using StringCalculator.Parser;
using StringCalculator.Processor;

namespace StringCalculator
{
    public class StringCalculator
    {
        private readonly IParser _parser;
        private readonly IProcessor _processor;

        public StringCalculator(IParser parser, IProcessor processor)
        {
            _parser = parser;
            _processor = processor;
        }

        public int Add(string message)
        {
            var numbers = _parser.Parse(message);
            return _processor.Process(numbers);
        }
    }
}