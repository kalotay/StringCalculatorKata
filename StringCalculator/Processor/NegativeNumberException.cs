using System;
using System.Collections.Generic;
using System.Linq;


namespace StringCalculator.Processor
{
    public class NegativeNumberException : Exception
    {
        public readonly int[] NegativeNumbers;

        private const string MessagePrefix = "Received following negative numbers: ";

        private readonly string _message;

        public NegativeNumberException(IEnumerable<int> negativeNumbers)
        {
            NegativeNumbers = negativeNumbers.ToArray();
            _message = MessagePrefix + string.Join(", ", NegativeNumbers);
        }

        public override string Message
        {
            get { return _message; }
        }
    }
}