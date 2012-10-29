using NUnit.Framework;

namespace StringCalculator.Lexer
{
    [TestFixture]
    public class LexerTests
    {
        [Test]
        public void EmptyMessageReturnsEmptyEnumerable()
        {
            var lexer = new StringCalculatorLexer(string.Empty);
            var tokens = lexer.Read();

            Assert.That(tokens, Is.Empty);
        }
    }
}
