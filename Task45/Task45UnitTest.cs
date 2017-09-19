using System;
using System.Collections.Generic;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task45
{
    [TestClass]
    public class Task45UnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Negative()
        {
            Task45.InsertInSortedList(null, 1);
        }
        [TestMethod]
        public void OneElementLeft_Positive()
        {
            var input = new List<int> { 5 };
            Task45.InsertInSortedList(input, 1);
            input.Should().Equals(new List<int> { 1, 5 });
        }

        [TestMethod]
        public void OneElementRight_Positive()
        {
            var input = new List<int> { 5 };
            Task45.InsertInSortedList(input, 7);
            input.Should().Equals(new List<int> { 5, 7 });
        }

        [TestMethod]
        public void TwoElementsMiddle_Positive()
        {
            var input = new List<int> { 1, 5 };
            Task45.InsertInSortedList(input, 3);
            input.Should().Equals(new List<int> { 1, 3, 5 });
        }

        [TestMethod]
        public void ThreeElementsFirstHalf_Positive()
        {
            var input = new List<int> { 1, 3, 5 };
            Task45.InsertInSortedList(input, 2);
            input.Should().Equals(new List<int> { 1, 2, 3, 5 });
        }

        [TestMethod]
        public void ThreeElementsSecondHalf_Positive()
        {
            var input = new List<int> { 1, 3, 5 };
            Task45.InsertInSortedList(input, 4);
            input.Should().Equals(new List<int> { 1, 3, 4, 5 });
        }

        [TestMethod]
        public void ManyElements_Positive()
        {
            var input = new List<int> { 1, 3, 5, 10, 20, 35, 42, 71, 82, 90, 100, 1000, 5000 };
            Task45.InsertInSortedList(input, 150);
            input.Should().Equals(new List<int> { 1, 3, 5, 10, 20, 35, 42, 71, 82, 90, 100, 150, 1000, 5000 });
        }
    }
}