using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentAssertions;

namespace OnlineTask3
{
    [TestClass]
    public class OnlineTask3UnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Null()
        {
            OnlineTask3.GetMinimumNotPresent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Empty()
        {
            OnlineTask3.GetMinimumNotPresent(new int[0]);
        }

        [TestMethod]
        public void Min()
        {
            OnlineTask3.GetMinimumNotPresent(new int[] { int.MinValue }).Should().Be(int.MinValue + 1);
        }

        [TestMethod]
        public void Max()
        {
            OnlineTask3.GetMinimumNotPresent(new int[] { int.MaxValue }).Should().Be(int.MaxValue - 1);
        }

        [TestMethod]
        public void Zero()
        {
            OnlineTask3.GetMinimumNotPresent(new int[] { 0 }).Should().Be(1);
        }

        [TestMethod]
        public void NegativeSolid()
        {
            OnlineTask3.GetMinimumNotPresent(new int[] { -3, -2, -1 }).Should().Be(0);
        }

        [TestMethod]
        public void NegativeGap()
        {
            OnlineTask3.GetMinimumNotPresent(new int[] { -3, -1 }).Should().Be(-2);
        }

        [TestMethod]
        public void PositiveSolid()
        {
            OnlineTask3.GetMinimumNotPresent(new int[] { 1, 2, 3 }).Should().Be(4);
        }

        [TestMethod]
        public void PositiveGap()
        {
            OnlineTask3.GetMinimumNotPresent(new int[] { 1, 3 }).Should().Be(2);
        }
    }
}