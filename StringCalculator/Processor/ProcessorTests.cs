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

    }
}