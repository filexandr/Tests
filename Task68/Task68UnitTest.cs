using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentAssertions;

namespace Task68
{
    [TestClass]
    public class Task68UnitTest
    {
        [TestMethod]
        public void Test()
        {
            Task68.ReverseInteger(0).Should().Be(0);
            Task68.ReverseInteger(UInt32.MaxValue).Should().Be(UInt32.MaxValue);
            Task68.ReverseInteger(UInt32.MaxValue).Should().Be(UInt32.MaxValue);
            Task68.ReverseInteger(255).Should().Be(unchecked ((uint)-16777216));
        }
    }
}