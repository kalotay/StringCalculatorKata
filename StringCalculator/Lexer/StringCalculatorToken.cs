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

        public static readonly StringCalculatorToken DelimitersStart = new StringCalculatorToken {Type = Types.DelimitersStart};
        public static readonly StringCalculatorToken DelimitersEnd = new StringCalculatorToken {Type = Types.DelimitersEnd};
        public static readonly StringCalculatorToken MultiCharacterDelimiterStart = new StringCalculatorToken {Type = Types.MultiCharacterDelimterStart};
        public static readonly StringCalculatorToken MultiCharacterDelimiterEnd = new StringCalculatorToken { Type = Types.MultiCharacterDelimiterEnd};
    }
}
