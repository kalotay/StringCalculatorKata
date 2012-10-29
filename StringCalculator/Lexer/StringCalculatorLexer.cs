using System.Collections.Generic;

namespace StringCalculator.Lexer
{
    public class StringCalculatorLexer
    {
        private string _message;

        public StringCalculatorLexer(string message)
        {
             _message = message;
        }

        public IEnumerable<StringCalculatorToken> Read()
        {
            yield break;
        }
    }
}
