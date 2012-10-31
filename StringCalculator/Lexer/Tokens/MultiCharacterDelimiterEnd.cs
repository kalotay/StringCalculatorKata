namespace StringCalculator.Lexer.Tokens
{
    public class MultiCharacterDelimiterEnd : IToken
    {
        public string Content { get; private set; }

        public static readonly MultiCharacterDelimiterEnd Token = new MultiCharacterDelimiterEnd { Content = "]" };

        private MultiCharacterDelimiterEnd()
        {
        }

    }
}
