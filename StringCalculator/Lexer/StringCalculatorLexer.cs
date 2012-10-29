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
            if (string.IsNullOrEmpty(_message))
            {
                yield break;
            }

            yield return new StringCalculatorToken {Content = _message, Type = StringCalculatorToken.Types.Numbers};
        }
    }
}
