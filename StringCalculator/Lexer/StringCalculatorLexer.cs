using System.Collections.Generic;
using System.Text;

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
                yield return StringCalculatorToken.DelimitersStart;
            }

            while (hasDelimiterSpec)
            {
                var currentChar = _message[_position];
                _position += 1;

                if (currentChar == '\n')
                {
                    hasDelimiterSpec = false;
                    yield return StringCalculatorToken.DelimitersEnd;
                }
                else if (currentChar == '[')
                {
                    yield return StringCalculatorToken.MultiCharacterDelimiterStart;
                    var delimiterLength = 0;
                    while (_message[_position + delimiterLength] != ']')
                    {
                        delimiterLength += 1;
                    }
                    yield return new StringCalculatorToken {Type = StringCalculatorToken.Types.Delimiter, Content = _message.Substring(_position, delimiterLength)};
                    _position += (delimiterLength + 1);
                    yield return StringCalculatorToken.MultiCharacterDelimiterEnd;
                }
                else
                {
                    yield return EmitSingleCharacterDelimiterToken(currentChar);
                }
            }

            yield return EmitNumbers();
        }

        private StringCalculatorToken EmitNumbers()
        {
            return new StringCalculatorToken {Content = _message.Substring(_position), Type = StringCalculatorToken.Types.Numbers};
        }

        private static StringCalculatorToken EmitSingleCharacterDelimiterToken(char currentChar)
        {
            return new StringCalculatorToken {Type = StringCalculatorToken.Types.Delimiter, Content = new string(currentChar, 1)};
        }

        private void Reset()
        {
            _position = 0;
        }

    }
}
