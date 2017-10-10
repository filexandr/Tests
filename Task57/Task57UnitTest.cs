using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentAssertions;

namespace Task57
{
    [TestClass]
    public class Task57UnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WrongK()
        {
            Task57.SortArray(new int[] { 1, 2, 3 }, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void WrongElement()
        {
            var input = new int[] {1, 100, 1, 1, 1};
            Task57.SortArray(input, 10);
        }

        [TestMethod]
        public void EmptyOrOneElement()
        {
            Task57.SortArray(null, 10);
            Task57.SortArray(new int[0], 10);

            var input = new int[] {1};
            Task57.SortArray(input, 10);
            input.Should().Equal(new int[] {1});
        }

        [TestMethod]
        public void TheSameElement()
        {
            var input = new int[] {1, 1, 1, 1, 1};
            Task57.SortArray(input, 10);
            input.Should().Equal(new int[] {1, 1, 1, 1, 1});
        }

        [TestMethod]
        public void DifferentElements()
        {
            var input = new int[] {10, 5, 7, 7, 5, 3, 10, 1, 10};
            Task57.SortArray(input, 10);
            input.Should().Equal(new int[] {1, 3, 5, 5, 7, 7, 10, 10, 10});
        }
    }
}