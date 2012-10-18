using System.Linq;
using NUnit.Framework;

namespace StringCalculator
{
    [TestFixture]
    public class DelimiterParserTests
    {
        private IDelimiterParser _delimiterParser;

        [SetUp]
        public void CreateNewDelimiterParser()
        {
            _delimiterParser = new DelimiterParser();
        }

        [Test]
        public void InitialDelimitersIsEmpty()
        {
            Assert.That(_delimiterParser.Delimiters, Is.Empty);
        }

        [Test]
        public void InitialParentIsNull()
        {
            Assert.That(_delimiterParser.Parent, Is.Null);
        }

        [Test]
        public void ReadingANormalCharacterReturnsThis()
        {
            var nextParser = _delimiterParser.Read(';');

            Assert.That(nextParser, Is.SameAs(nextParser));
        }

        [Test]
        public void ReadingANormalCharacterStoresIt()
        {
            var nextParser = _delimiterParser.Read(';');

            Assert.That(nextParser.Delimiters, Contains.Item(";"));
        }

        [Test]
        public void ReadingACharacterSequenceStoresThem()
        {
            var nextParser = ",;.-".Aggregate(_delimiterParser, (currentParser, character) => currentParser.Read(character));

            Assert.That(nextParser.Delimiters, Contains.Item(";"));
            Assert.That(nextParser.Delimiters, Contains.Item(","));
            Assert.That(nextParser.Delimiters, Contains.Item("."));
            Assert.That(nextParser.Delimiters, Contains.Item("-"));
        }
    }
}