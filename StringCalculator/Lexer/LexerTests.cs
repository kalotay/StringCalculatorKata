using System.Linq;
using NUnit.Framework;
using StringCalculator.Lexer.Tokens;

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

        [Test]
        public void SingleCharacterDelimitersCanBeSpecified()
        {
            var lexer = new StringCalculatorLexer("//;_\n1;2_3");
            var tokens = lexer.Read().ToArray();
            var semiColon = tokens[1];
            var underScore = tokens[2];
            var numbers = tokens[4];

            Assert.That(tokens.Count(), Is.EqualTo(5));

            Assert.That(tokens[0], Is.EqualTo(StringCalculatorToken.DelimitersStart));

            Assert.That(semiColon.Type, Is.EqualTo(StringCalculatorToken.Types.Delimiter));
            Assert.That(semiColon.Content, Is.EqualTo(";"));
            Assert.That(underScore.Type, Is.EqualTo(StringCalculatorToken.Types.Delimiter));
            Assert.That(underScore.Content, Is.EqualTo("_"));

            Assert.That(tokens[3], Is.EqualTo(StringCalculatorToken.DelimitersEnd));

            Assert.That(numbers.Type, Is.EqualTo(StringCalculatorToken.Types.Numbers));
            Assert.That(numbers.Content, Is.EqualTo("1;2_3"));
        }

        [Test]
        public void MultipleCaharacterDelimitersCanBeSpecified()
        {
            var lexer = new StringCalculatorLexer("//[:-]\n1:-2");
            var tokens = lexer.Read().ToArray();
            var delimiter = tokens[2];
            var numbers = tokens[5];

            Assert.That(tokens.Count(), Is.EqualTo(6));

            Assert.That(tokens[0], Is.EqualTo(StringCalculatorToken.DelimitersStart));
            Assert.That(tokens[1], Is.EqualTo(StringCalculatorToken.MultiCharacterDelimiterStart));

            Assert.That(delimiter.Type, Is.EqualTo(StringCalculatorToken.Types.Delimiter));
            Assert.That(delimiter.Content, Is.EqualTo(":-"));

            Assert.That(tokens[3], Is.EqualTo(StringCalculatorToken.MultiCharacterDelimiterEnd));
            Assert.That(tokens[4], Is.EqualTo(StringCalculatorToken.DelimitersEnd));

            Assert.That(numbers.Type, Is.EqualTo(StringCalculatorToken.Types.Numbers));
            Assert.That(numbers.Content, Is.EqualTo("1:-2"));
        }

    }
}
