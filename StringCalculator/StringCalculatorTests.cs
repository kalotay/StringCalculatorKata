using System;
using NUnit.Framework;

namespace StringCalculator
{
    [TestFixture]
    public class StringCalculatorTests
    {
        private readonly StringCalculator _stringCalculator = new StringCalculator();

        [Test]
        public void EmptyStringReturnsZero()
        {
            var result = _stringCalculator.Add(String.Empty);

            Assert.That(result, Is.EqualTo(0));
        }

        [TestCase("1", 1)]
        [TestCase("2", 2)]
        public void SingleNumberReturnsItself(string number, int expected)
        {
            NumberSequenceReturnsTheSum(number, expected);
        }
       
        [TestCase("2,3", 5)]
        [TestCase("11,9", 20)]
        public void TwoNumbersReturnTheirSum(string numbers, int expected)
        {
            NumberSequenceReturnsTheSum(numbers, expected);
        }

        [TestCase("1,2,3", 6)]
        public void ThreeNumbersReturnTheirSum(string numbers, int expected)
        {
            NumberSequenceReturnsTheSum(numbers, expected);
        }

        [TestCase("8\n9", 17)]
        public void TwoNumbersSeperatedByNewlineReturnTheirSum(string numbers, int expected)
        {
            NumberSequenceReturnsTheSum(numbers, expected);
        }

        [TestCase("1\n2,3", 6)]
        public void ThreeNumbersSeperatedByNewlineAndCommaReturnTheirSum(string numbers, int expected)
        {
            NumberSequenceReturnsTheSum(numbers, expected);
        }

        [TestCase("//;\n1;2", 3)]
        public void DelimiterCanBeSpecified(string delimitersAndNumbers, int expected)
        {
            NumberSequenceReturnsTheSum(delimitersAndNumbers, expected);
        }

        [Test]
        public void NegativeNumbersThrowException()
        {
            var exception = Assert.Throws<NegativeNumberException>(() => _stringCalculator.Add("-1"));
            Assert.That(exception.Message, Is.EqualTo("Received following negative numbers: -1"));
        }

        [Test]
        public void TwoNegativeNumbersAreBothReportedInException()
        {
            var exception = Assert.Throws<NegativeNumberException>(() => _stringCalculator.Add("-1,-2"));
            Assert.That(exception.Message, Is.EqualTo("Received following negative numbers: -1 -2"));
        }

        private void NumberSequenceReturnsTheSum(string delimitersAndNumbers, int expected)
        {
            var result = _stringCalculator.Add(delimitersAndNumbers);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}