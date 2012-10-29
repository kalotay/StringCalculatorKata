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
                yield return StringCalculatorToken.DelimitersStart;
            }

            while (hasDelimiterSpec)
            {
                var currentChar = _message[_position];
                _position += 1;

                switch (currentChar)
                {
                    case '\n':
                        hasDelimiterSpec = false;
                        yield return StringCalculatorToken.DelimitersEnd;
                        break;

                    case '[':
                        yield return StringCalculatorToken.MultiCharacterDelimiterStart;
                        yield return EmitMultiCharacterDelimiterToken();
                        yield return StringCalculatorToken.MultiCharacterDelimiterEnd;
                        break;

                    default:
                        yield return EmitSingleCharacterDelimiterToken(currentChar);
                        break;
                }
            }

            yield return EmitNumbers();
        }

        private StringCalculatorToken EmitMultiCharacterDelimiterToken()
        {
            var delimiterStart = _position;
            var delimiterLength = 0;
            while (_message[delimiterStart + delimiterLength] != ']')
            {
                delimiterLength += 1;
            }
            _position += (delimiterLength + 1);
            var delimiter = _message.Substring(delimiterStart, delimiterLength);

            return StringCalculatorToken.DelimiterToken(delimiter);
        }

        private StringCalculatorToken EmitNumbers()
        {
            var numbers = _message.Substring(_position);
            return StringCalculatorToken.NumbersToken(numbers);
        }

        private static StringCalculatorToken EmitSingleCharacterDelimiterToken(char currentChar)
        {
            var delimiter = new string(currentChar, 1);
            return StringCalculatorToken.DelimiterToken(delimiter);
        }

        private void Reset()
        {
            _position = 0;
        }

    }
}
