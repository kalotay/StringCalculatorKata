namespace StringCalculator.Lexer.Tokens
{
    public class DelimiterSpecStart: IToken
    {
        public string Content { get; private set; }

        public static readonly DelimiterSpecStart Token = new DelimiterSpecStart {Content = "//"};

        private DelimiterSpecStart()
        {
        }
    }
}
