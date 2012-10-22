using NUnit.Framework;

namespace StringCalculator.Processor
{
    [TestFixture]
    class ProcessorTests
    {
        private MyAdder _processor;

        [SetUp]
        public void CreateProcessor()
        {
            _processor = new MyAdder();
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

    }
}