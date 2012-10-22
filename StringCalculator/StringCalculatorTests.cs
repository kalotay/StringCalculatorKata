using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using StringCalculator.Parser;
using StringCalculator.Processor;

namespace StringCalculator
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [Test]
        public void CorrectMethodsAreCalled()
        {
            var empty = string.Empty;

            var parser = Substitute.For<IParser>();
            parser.Parse(Arg.Any<string>()).Returns(new int[0]);

            var processor = Substitute.For<IProcessor>();
            processor.Process(Arg.Any<IEnumerable<int>>()).Returns(0);

            var stringCalculator = new StringCalculator(parser, processor);
            var result = stringCalculator.Add(empty);

            Assert.That(result, Is.EqualTo(0));
            parser.Received().Parse(empty);
            processor.Received().Process(Arg.Any<int[]>());
        }
    }
}