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
            var number = _parser.Parse("16").ToArray();

            Assert.That(number.Length, Is.EqualTo(1));
            Assert.That(number, Contains.Item(16));
        }

    }
}
