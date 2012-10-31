namespace StringCalculator.Lexer.Tokens
{
    public class DelimiterSpecEnd: IToken
    {

        public string Content { get; private set; }

        public static readonly DelimiterSpecEnd Token = new DelimiterSpecEnd {Content = "\n"};

        private DelimiterSpecEnd()
        {
        }

    }
}
