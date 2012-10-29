﻿using System.Linq;
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

        [Test]
        public void SingleCharacterDelimitersCanBeSpecified()
        {
            var lexer = new StringCalculatorLexer("//;_\n1;2_3");
            var tokens = lexer.Read().ToArray();
            var semiColon = tokens[1];
            var underScore = tokens[2];
            var numbers = tokens[4];

            Assert.That(tokens.Count(), Is.EqualTo(5));

            Assert.That(tokens[0].Type, Is.EqualTo(StringCalculatorToken.Types.DelimitersStart));

            Assert.That(semiColon.Type, Is.EqualTo(StringCalculatorToken.Types.Delimiter));
            Assert.That(semiColon.Content, Is.EqualTo(";"));
            Assert.That(underScore.Type, Is.EqualTo(StringCalculatorToken.Types.Delimiter));
            Assert.That(underScore.Content, Is.EqualTo("_"));

            Assert.That(tokens[3].Type, Is.EqualTo(StringCalculatorToken.Types.DelimitersEnd));

            Assert.That(numbers.Type, Is.EqualTo(StringCalculatorToken.Types.Numbers));
            Assert.That(numbers.Content, Is.EqualTo("1;2_3"));
        }
    }
}
