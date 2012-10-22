using NUnit.Framework;

namespace StringCalculator.Processor
{
    [TestFixture]
    class ProcessorTests
    {
        private Adder _processor;

        [SetUp]
        public void CreateProcessor()
        {
            _processor = new Adder();
        }

        [Test]
        public void EmptySequenceReturnsZero()
        {
            var sum = _processor.Process(new int[0]);

            Assert.That(sum, Is.EqualTo(0));
        }

        [Test]
        public void SinlgeNumberReturnsItself()
        {
            var sum = _processor.Process(new[] {10});

            Assert.That(sum, Is.EqualTo(10));
        }

        [Test]
        public void PositiveNumberSequenceReturnsTheSum()
        {
            var sum = _processor.Process(new[] {1, 2, 3, 4});

            Assert.That(sum, Is.EqualTo(10));
        }

        [Test]
        public void PositiveNumbersFrom1000AreIgnored()
        {
            var sum = _processor.Process(new[] {10000, 1000, 100, 10});

            Assert.That(sum, Is.EqualTo(110));
        }

        [Test]
        public void SequencesWithNegativeNumbersThrowException()
        {
            Assert.Throws<NegativeNumberException>(() => _processor.Process(new[] {-1}));
        }

        [Test]
        public void NegativeNumberExceptionsMessageContainsNegativeNumberSequence()
        {
            var exception = Assert.Throws<NegativeNumberException>(() => _processor.Process(new[] {-1, 2, -5}));
            Assert.That(exception.Message, Is.StringContaining("-1, -5"));
        }
    }
}