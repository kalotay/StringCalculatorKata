namespace StringCalculator.Lexer.Tokens
{
    public class MultiCharacterDelimiterStart : IToken
    {
        public string Content { get; private set; }

        public static readonly MultiCharacterDelimiterStart Token = new MultiCharacterDelimiterStart { Content = "[" };

        private MultiCharacterDelimiterStart()
        {
        }

    }
}
