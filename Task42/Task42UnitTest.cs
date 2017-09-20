using System;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task42
{
    [TestClass]
    public class Task42UnitTest
    {
        [TestMethod]
        public void Negative()
        {
            Task42.IsPowerOfTwo(-1).Should().BeFalse();
            Task42.IsPowerOfTwo(0).Should().BeFalse();
            for (int i = 3; i < 100; i += 2)
            {
                Task42.IsPowerOfTwo(i).Should().BeFalse();
            }
        }

        [TestMethod]
        public void Positive()
        {
            for (int i = 0; i <= 30; i++)
            {
                Task42.IsPowerOfTwo((int)Math.Pow(2, i)).Should().BeTrue();
            }
        }
    }
}