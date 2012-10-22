using System.Linq;
using NUnit.Framework;

namespace StringCalculator.Parser
{
    [TestFixture]
    class ParserTests
    {
        private IParser _parser;

        [SetUp]
        public void CreateParser()
        {
            _parser = new MessageParser(new[] {",", "\n"});
        }

        [Test]
        public void EmptyStringReturnsEmpty()
        {
            var numbers = _parser.Parse(string.Empty);

            Assert.That(numbers, Is.Empty);
        }

        [Test]
        public void SingleNumberStringReturnsSingleItemSequenceWithNumber()
        {
            var number = _parser.Parse("16");

            Assert.That(number.Count(), Is.EqualTo(1));
            Assert.That(number, Contains.Item(16));
        }

        [Test]
        public void NumbersCanBeCommaSeparated()
        {
            var numbers = _parser.Parse("10,9,8");

            Assert.That(numbers.Count(), Is.EqualTo(3));
            Assert.That(numbers, Contains.Item(10));
            Assert.That(numbers, Contains.Item(9));
            Assert.That(numbers, Contains.Item(8));
        }

        [Test]
        public void NumbersCanBeNewlineSeparated()
        {
            var numbers = _parser.Parse("7\n6\n5");

            Assert.That(numbers.Count(), Is.EqualTo(3));
            Assert.That(numbers, Contains.Item(7));
            Assert.That(numbers, Contains.Item(6));
            Assert.That(numbers, Contains.Item(5));
        }

        [Test]
        public void NumbersCanBeCommaAndNewlineSeparated()
        {
            var numbers = _parser.Parse("4,3\n2");

            Assert.That(numbers.Count(), Is.EqualTo(3));
            Assert.That(numbers, Contains.Item(4));
            Assert.That(numbers, Contains.Item(3));
            Assert.That(numbers, Contains.Item(2));
        }

        [Test]
        public void DelimitersCanBeSpecified()
        {
            var numbers = _parser.Parse("//;_\n1;0_-1");

            Assert.That(numbers.Count(), Is.EqualTo(3));
            Assert.That(numbers, Contains.Item(1));
            Assert.That(numbers, Contains.Item(0));
            Assert.That(numbers, Contains.Item(-1));
        }

        [Test]
        public void MultiCharDelimitersCanBeSpecified()
        {
            var numbers = _parser.Parse("//[_:]\n1000_:100");

            Assert.That(numbers.Count(), Is.EqualTo(2));
            Assert.That(numbers, Contains.Item(1000));
            Assert.That(numbers, Contains.Item(100));
        }

        [Test]
        public void MultiCharDelimitersCanContainNewlines()
        {
            var numbers = _parser.Parse("//[;\n]\n1;\n2");

            Assert.That(numbers.Count(), Is.EqualTo(2));
            Assert.That(numbers, Contains.Item(1));
            Assert.That(numbers, Contains.Item(2));
        }

        [Test]
        public void MultiCharDelimitersCanContainOpeningSquareBrace()
        {
            var numbers = _parser.Parse("//[;[]\n1;[2");

            Assert.That(numbers.Count(), Is.EqualTo(2));
            Assert.That(numbers, Contains.Item(1));
            Assert.That(numbers, Contains.Item(2));
        }

        [Test]
        public void MultiCharacterDelimiterSubsetOfAnotherCanBeSpecified()
        {
            var numbers = _parser.Parse("//[aa][aaa]\n1aaa2aa3");

            Assert.That(numbers.Count(), Is.EqualTo(3));
            Assert.That(numbers, Contains.Item(1));
            Assert.That(numbers, Contains.Item(2));
            Assert.That(numbers, Contains.Item(3));
        }


    }
}
