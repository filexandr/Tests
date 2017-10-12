using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentAssertions;

namespace Task59
{
    [TestClass]
    public class Task59UnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Null()
        {
            Task59.CalcSum(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Empty()
        {
            Task59.CalcSum(new int[0]);
        }

        [TestMethod]
        public void Test()
        {
            Task59.CalcSum(new[] { 1 }).Should().Be(1);
            Task59.CalcSum(new[] { -1 }).Should().Be(-1);
            Task59.CalcSum(new[] { -1, 1 }).Should().Be(0);
            Task59.CalcSum(new[] {1, 2, 3}).Should().Be(6);
            Task59.CalcSum(new[] {10, 100, -50, 40, -25}).Should().Be(75);
            Task59.CalcSum(new[] {-10, -100, 50, -40, 25}).Should().Be(-75);
            Task59.CalcSum(new[] {int.MaxValue, -1}).Should().Be(int.MaxValue - 1);
            Task59.CalcSum(new[] {int.MinValue, 1}).Should().Be(int.MinValue + 1);
        }
    }
}