using System.Linq;
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

        [Test]
        public void NoStartingDoubleSlashReturnsSingleNumberToken()
        {
            var lexer = new StringCalculatorLexer("1,2,3");
            var tokens = lexer.Read().ToArray();
            var numbers = tokens.First();

            Assert.That(tokens.Count(), Is.EqualTo(1));
            Assert.That(numbers.Type, Is.EqualTo(StringCalculatorToken.Types.Numbers));
            Assert.That(numbers.Content, Is.EqualTo("1,2,3"));
        }
    }
}
