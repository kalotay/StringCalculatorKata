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
        public void ReadingAormalCharacterSequenceStoresThem()
        {
            var nextParser = ",;.-".Aggregate(_delimiterParser,
                                              (currentParser, character) => currentParser.Read(character));

            Assert.That(nextParser.Delimiters, Contains.Item(";"));
            Assert.That(nextParser.Delimiters, Contains.Item(","));
            Assert.That(nextParser.Delimiters, Contains.Item("."));
            Assert.That(nextParser.Delimiters, Contains.Item("-"));
        }

        [Test]
        public void ReadingANormalCharacterSeqenceReturnsThis()
        {
            var nextParser = ",;.-".Aggregate(_delimiterParser,
                                              (currentParser, character) => currentParser.Read(character));

            Assert.That(nextParser, Is.SameAs(nextParser));
        }

        [Test]
        public void InitiallyParserHasNotTerminated()
        {
            Assert.That(_delimiterParser.HasTerminated, Is.False);
        }

        [Test]
        public void ReadingNormalCharacterDoesNotTerminate()
        {
            var nextParser = _delimiterParser.Read(';');

            Assert.That(nextParser.HasTerminated, Is.False);
        }

        [Test]
        public void ReadingNormalCharacterSequenceDoesNotTerminate()
        {
            var nextParser = ",;.-".Aggregate(_delimiterParser,
                                              (currentParser, character) => currentParser.Read(character));

            Assert.That(nextParser.HasTerminated, Is.False);
        }

        [Test]
        public void ReadingNewLineTerminatesTheParser()
        {
            var nextParser = _delimiterParser.Read('\n');

            Assert.That(nextParser.HasTerminated, Is.True);
        }

        [Test]
        public void ReadingNewLineAfterCharaceterSequenceTerminatesTheParser()
        {
            var nextParser = ",;.-\n".Aggregate(_delimiterParser,
                                                (currentParser, character) => currentParser.Read(character));

            Assert.That(nextParser.HasTerminated, Is.True);
        }

        [Test]
        public void ReadingAfterTerminationThrowsException()
        {
            var nextParser = _delimiterParser.Read('\n');

            var exception = Assert.Throws<ParserTerminatedException>(() => nextParser.Read(','));
        }

        [Test]
        public void ReadingOpeningSquareBracketReturnsMultiCharacterDelimiterParser()
        {
            var nextParser = _delimiterParser.Read('[');

            Assert.That(nextParser, Is.InstanceOf<MultiCharacterDelimiterParser>());
        }

        [Test]
        public void MultiCharacterDelimiterParserHasNotTerminated()
        {
            var nextParser = _delimiterParser.Read('[');

            Assert.That(nextParser.HasTerminated, Is.False);
        }

        [Test]
        public void MultiCharacterDelimiterParserStoresParentParser()
        {
            var nextParser = (MultiCharacterDelimiterParser) _delimiterParser.Read('[');

            Assert.That(nextParser.ParentParser, Is.SameAs(_delimiterParser));
        }

        [Test]
        public void DelimitersInMultiCharacterDelimiterShouldForwardToParentParsers()
        {
            var nextParser = (MultiCharacterDelimiterParser) _delimiterParser.Read('[');

            Assert.That(nextParser.Delimiters, Is.SameAs(_delimiterParser.Delimiters));
        }

        [Test]
        public void MultiCharacterDelimiterParserReturnParentParserAfterClosingSquareBrackets()
        {
            var nextParser = "[]".Aggregate(_delimiterParser,
                                    (currentParser, character) => currentParser.Read(character));

            Assert.That(nextParser, Is.SameAs(_delimiterParser));
        }
    }

}