namespace StringCalculator.Lexer.Tokens
{
    public struct DelimiterToken: IToken
    {
        public string Content { get; private set; }

        public DelimiterToken(string content) : this()
        {
            Content = content;
        }
    }
}
