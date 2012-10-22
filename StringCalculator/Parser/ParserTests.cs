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
            _parser = new MessageParser();
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

    }
}
