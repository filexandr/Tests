using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentAssertions;

namespace Task58
{
    [TestClass]
    public class Task58UnitTest
    {
        [TestMethod]
        public void EmptyAndSingle()
        {
            Task58.ContainDuplicates(null).Should().Be(false);
            Task58.ContainDuplicates(new int[0]).Should().Be(false);
            Task58.ContainDuplicates(new int[] {1}).Should().Be(false);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WrongEntry()
        {
            Task58.ContainDuplicates(new int[] {10, 10});
        }

        [TestMethod]
        public void NoDuplicates()
        {
            Task58.ContainDuplicates(new int[] {1, 2, 3, 4, 5}).Should().Be(false);
        }

        [TestMethod]
        public void Duplicates()
        {
            Task58.ContainDuplicates(new int[] {1, 2, 3, 4, 5, 5}).Should().Be(true);
            Task58.ContainDuplicates(new int[] {1, 1, 2, 3, 4, 5, 2}).Should().Be(true);
        }
    }
}