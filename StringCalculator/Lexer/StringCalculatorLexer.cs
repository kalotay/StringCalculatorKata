using System.Collections.Generic;
using StringCalculator.Lexer.Tokens;

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

        public IEnumerable<IToken> Read()
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
                yield return DelimiterSpecStart.Token;
            }

            while (hasDelimiterSpec)
            {
                var currentChar = _message[_position];
                _position += 1;

                switch (currentChar)
                {
                    case '\n':
                        hasDelimiterSpec = false;
                        yield return DelimiterSpecEnd.Token;
                        break;

                    case '[':
                        yield return MultiCharacterDelimiterStart.Token;
                        yield return EmitMultiCharacterDelimiterToken();
                        yield return MultiCharacterDelimiterEnd.Token;
                        break;

                    default:
                        yield return EmitSingleCharacterDelimiterToken(currentChar);
                        break;
                }
            }

            yield return EmitNumbers();
        }

        private IToken EmitMultiCharacterDelimiterToken()
        {
            var delimiterStart = _position;
            var delimiterLength = 0;
            while (_message[delimiterStart + delimiterLength] != ']')
            {
                delimiterLength += 1;
            }
            _position += (delimiterLength + 1);
            var delimiter = _message.Substring(delimiterStart, delimiterLength);

            return new DelimiterToken(delimiter);
        }

        private IToken EmitNumbers()
        {
            var numbers = _message.Substring(_position);
            return new NumbersToken(numbers);
        }

        private static IToken EmitSingleCharacterDelimiterToken(char currentChar)
        {
            var delimiter = new string(currentChar, 1);
            return new DelimiterToken(delimiter);
        }

        private void Reset()
        {
            _position = 0;
        }

    }
}
