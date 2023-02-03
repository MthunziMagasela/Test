using Calculator;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using System;

namespace CalculatorTests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase("", 0)]
        [TestCase("1", 1)]
        [TestCase("1,2", 3)]
        [TestCase("1\n2,3", 6)]
        [TestCase("//;\n1;2", 3)]
        public void Add_ShouldReturnExpectedResult(string numbers, int expectedResult)
        {
            var calculator = new StringCalculator();

            var result = calculator.Add(numbers);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Add_ShouldThrowExceptionForNegativeNumbers()
        {
            var calculator = new StringCalculator();

            var exception = Assert.Throws<Exception>(() => calculator.Add("-1,2,-3"));

            Assert.AreEqual("Negatives not allowed: -1, -3", exception.Message);
        }
    }
}
    