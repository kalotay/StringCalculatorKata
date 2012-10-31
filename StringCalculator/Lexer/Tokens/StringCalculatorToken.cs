namespace StringCalculator.Lexer.Tokens
{
    public struct StringCalculatorToken: IToken
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

        public readonly Types Type;
        public string Content { get; private set; }

        public static readonly StringCalculatorToken DelimitersStart =
            new StringCalculatorToken(Types.DelimitersStart, "//");

        public static readonly StringCalculatorToken DelimitersEnd =
            new StringCalculatorToken(Types.DelimitersEnd, "\n");

        public static readonly StringCalculatorToken MultiCharacterDelimiterStart =
            new StringCalculatorToken(Types.MultiCharacterDelimterStart, "[");

        public static readonly StringCalculatorToken MultiCharacterDelimiterEnd =
            new StringCalculatorToken(Types.MultiCharacterDelimiterEnd, "]");

        public static StringCalculatorToken DelimiterToken(string content)
        {
            return new StringCalculatorToken(Types.Delimiter, content);
        }

        public static StringCalculatorToken NumbersToken(string content)
        {
            return new StringCalculatorToken(Types.Numbers, content);
        }

        private StringCalculatorToken(Types type, string content) : this()
        {
            Type = type;
            Content = content;
        }

    }
}
