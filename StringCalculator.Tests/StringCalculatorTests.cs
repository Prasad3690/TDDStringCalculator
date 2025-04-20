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
    }
}
