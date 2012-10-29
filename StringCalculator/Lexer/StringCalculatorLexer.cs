using System.Collections.Generic;

namespace StringCalculator.Lexer
{
    public class StringCalculatorLexer
    {
        private readonly string _message;
        private int _position;

        public StringCalculatorLexer(string message)
        {
             _message = message;
            Reset();
        }

        public IEnumerable<StringCalculatorToken> Read()
        {
            if (string.IsNullOrEmpty(_message))
            {
                yield break;
            }

            var hasDelimiterSpec = false;

            if (_message.StartsWith("//"))
            {
                hasDelimiterSpec = true;
                _position += 2;
                yield return new StringCalculatorToken {Type = StringCalculatorToken.Types.DelimitersStart};
            }

            while (hasDelimiterSpec)
            {
                var currentChar = _message[_position];
                _position += 1;

                if (currentChar == '\n')
                {
                    hasDelimiterSpec = false;
                    yield return new StringCalculatorToken {Type = StringCalculatorToken.Types.DelimitersEnd};
                }
                else
                {
                    yield return new StringCalculatorToken {Type = StringCalculatorToken.Types.Delimiter, Content = new string(currentChar, 1)};
                }
            }

            yield return new StringCalculatorToken {Content = _message.Substring(_position), Type = StringCalculatorToken.Types.Numbers};
        }        
        
        private void Reset()
        {
            _position = 0;
        }

    }
}
