using System;
using System.Collections.Generic;

namespace StringCalculator.Processor
{
    public class NegativeNumberException : Exception
    {
        private readonly string _message;
        private const string MessagePrefix = "Received following negative numbers: ";

        public NegativeNumberException(IEnumerable<int> negativeNumbers)
        {
            _message  = MessagePrefix + string.Join(", ", negativeNumbers);
        }

        public override string Message
        {
            get { return _message; }
        }
    }
}