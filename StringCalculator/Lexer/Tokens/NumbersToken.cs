namespace StringCalculator.Lexer.Tokens
{
    public struct NumbersToken: IToken
    {
        public string Content { get; private set; }

        public NumbersToken(string content) : this()
        {
            Content = content;
        }
    }
}
