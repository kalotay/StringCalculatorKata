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

        private void NumberSequenceReturnsTheSum(string number, int expected)
        {
            var result = _stringCalculator.Add(number);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}