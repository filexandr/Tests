using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentAssertions;

namespace Task52
{
    [TestClass]
    public class Task52UnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Negative()
        {
            Task52.EvaluateExpression(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Empty_Negative()
        {
            Task52.EvaluateExpression(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void WrongExpression_Negative()
        {
            Task52.EvaluateExpression("dsfsdf");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void WrongBrackets_Negative()
        {
            Task52.EvaluateExpression("10 + (1 + 1))");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void WrongOperation_Negative()
        {
            Task52.EvaluateExpression("++10");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Senseless_Negative()
        {
            Task52.EvaluateExpression("(())");
        }

        [TestMethod]
        public void Simple_Positive()
        {
            Task52.EvaluateExpression("10 + 5 - 5 / 2 * 3").Should().Be(15);
        }

        [TestMethod]
        public void WithNegativeValue_Positive()
        {
            Task52.EvaluateExpression("100 + -50").Should().Be(50);
        }

        [TestMethod]
        public void WithBrackets_Positive()
        {
            Task52.EvaluateExpression("110 + 2 + (1 + (100 / 5) * 1) + -50").Should().Be(83);
            Task52.EvaluateExpression("10 + 2 + (5 * 3) + (6 / 3) - 1").Should().Be(28);
        }
    }
}