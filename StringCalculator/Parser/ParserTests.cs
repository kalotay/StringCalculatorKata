using System.Collections.Generic;
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
        public void emptyStringReturnsEmpty()
        {
            var numbers = _parser.Parse(string.Empty);

            Assert.That(numbers, Is.Empty);
        }
    }

    internal class MessageParser : IParser
    {
        public IEnumerable<int> Parse(string message)
        {
            return (new int[0]).AsEnumerable();
        }
    }
}
