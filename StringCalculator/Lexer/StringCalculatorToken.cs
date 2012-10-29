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
    }
}
