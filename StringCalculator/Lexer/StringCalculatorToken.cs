namespace StringCalculator.Lexer
{
    public struct StringCalculatorToken
    {
        public enum Types
        {
            DelimitersStart,
            DelimitersEnd,
            Delimiter,
            MultiCharacterDelimterStart,
            MultiCharacterDelimiterEnd,
            Numbers
        }

        public Types Type;
        public string Content;

        public static readonly StringCalculatorToken DelimitersStart =
            new StringCalculatorToken {Type = Types.DelimitersStart, Content = "//"};

        public static readonly StringCalculatorToken DelimitersEnd =
            new StringCalculatorToken {Type = Types.DelimitersEnd, Content = "\n"};

        public static readonly StringCalculatorToken MultiCharacterDelimiterStart =
            new StringCalculatorToken {Type = Types.MultiCharacterDelimterStart, Content = "["};

        public static readonly StringCalculatorToken MultiCharacterDelimiterEnd =
            new StringCalculatorToken {Type = Types.MultiCharacterDelimiterEnd, Content = "]"};

        public static StringCalculatorToken DelimiterToken(string content)
        {
            return new StringCalculatorToken {Type = Types.Delimiter, Content = content};
        }

        public static StringCalculatorToken NumbersToken(string content)
        {
            return new StringCalculatorToken {Type = Types.Numbers, Content = content};
        }
    }
}
