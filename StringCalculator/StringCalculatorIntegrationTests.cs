using System;
using NUnit.Framework;
using StringCalculator.Parser;
using StringCalculator.Processor;

namespace StringCalculator
{
    [TestFixture]
    public class StringCalculatorIntegrationTests
    {
        private readonly StringCalculator _stringCalculator = new StringCalculator(new[] {",", "\n"}, new Adder());

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
        [TestCase("//[*][%]\n1*2%3", 6)]
        [TestCase("//;_\n1_3;3", 7)]
        [TestCase("//[_=]\n1_=2", 3)]
        [TestCase("//[#][@]\n1#2@3", 6)]
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
            Assert.That(exception.Message, Is.EqualTo("Received following negative numbers: -1, -2"));
        }

        [TestCase("1000", 0)]
        [TestCase("1000,1", 1)]
        [TestCase("9001", 0)]
        [TestCase("9001,2", 2)]
        public void OneThousandAndAboveShouldBeIgnored(string numbers, int expected)
        {
            NumberSequenceReturnsTheSum(numbers, expected);
        }


        private void NumberSequenceReturnsTheSum(string delimitersAndNumbers, int expected)
        {
            var result = _stringCalculator.Add(delimitersAndNumbers);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}