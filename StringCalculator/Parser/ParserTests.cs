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
    }
}
