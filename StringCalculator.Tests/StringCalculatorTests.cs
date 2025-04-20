using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorClass = StringCalculator.App.StringCalculator;

namespace StringCalculator.Tests
{
    [TestClass]
    public class StringCalculatorTests
    {
        private StringCalculatorClass _calculator;

        [TestInitialize]
        public void Setup()
        {
            _calculator = new StringCalculatorClass();
        }

        [TestMethod]
        public void Add_EmptyString_ReturnsZero()
        {
            Assert.AreEqual(0, _calculator.Add(""));
        }

        [TestMethod]
        public void Add_SingleNumber_ReturnsNumber()
        {
            Assert.AreEqual(1, _calculator.Add("1"));
        }

        [TestMethod]
        public void Add_TwoNumbers_ReturnsSum()
        {
            Assert.AreEqual(3, _calculator.Add("1,2"));
        }

        [TestMethod]
        public void Add_MultipleNumbers_ReturnsSum()
        {
            Assert.AreEqual(10, _calculator.Add("1,2,3,4"));
        }

        [TestMethod]
        public void Add_NewlineBetweenNumbers_ReturnsSum()
        {
            Assert.AreEqual(6, _calculator.Add("1\n2,3"));
        }

        [TestMethod]
        public void Add_CustomDelimiter_ReturnsSum()
        {
            Assert.AreEqual(6, _calculator.Add("//;\n1\n2;3"));
        }

        [TestMethod]
        public void Add_NegativeNumbers_ThrowsException()
        {
            var ex = Assert.ThrowsException<ArgumentException>(() => _calculator.Add("1,-2,-3,4,-5"));
            StringAssert.Contains(ex.Message, "negatives not allowed: -2, -3, -5");
        }

        [TestMethod]
        public void GetCalledCount_ReturnsCorrectInvocationCount()
        {
            _calculator.Add("1,2");
            _calculator.Add("3,4,5");
            Assert.AreEqual(2, _calculator.GetCalledCount());
        }

        [TestMethod]
        public void Add_EventFiresWithCorrectInputAndResult()
        {
            string receivedInput = null;
            int receivedResult = 0;

            _calculator.AddOccured += (input, result) =>
            {
                receivedInput = input;
                receivedResult = result;
            };

            _calculator.Add("1,2");

            Assert.AreEqual("1,2", receivedInput);
            Assert.AreEqual(3, receivedResult);
        }

        [TestMethod]
        public void Add_NumbersGreaterThan1000_IgnoredInSum()
        {
            Assert.AreEqual(2, _calculator.Add("2,1001"));
        }

        [TestMethod]
        public void Add_CustomDelimiterOfAnyLength_ReturnsSum()
        {
            Assert.AreEqual(6, _calculator.Add("//[***]\n1***2\n3"));
        }

        [TestMethod]
        public void Add_MultipleCustomDelimiters_ReturnsSum()
        {
            Assert.AreEqual(6, _calculator.Add("//[*][%]\n1*2%3"));
        }
    }
}
