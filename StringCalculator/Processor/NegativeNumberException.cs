using System;

namespace StringCalculator.Processor
{
    internal class NegativeNumberException : Exception
    {
        private string _message = "Received following negative numbers:";

        public void Add(string number)
        {
            _message += (" " + number);
        }

        public override string Message
        {
            get { return _message; }
        }

        public bool IsEmpty()
        {
            return Message == "Received following negative numbers:";
        }
    }
}