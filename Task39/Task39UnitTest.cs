using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentAssertions;

namespace Task39
{
    [TestClass]
    public class Task39UnitTest
    {
        [TestMethod]
        public void Null_Positive()
        {
            Task39.GetDuplicates(null).Should().BeEmpty();
        }

        [TestMethod]
        public void One_Positive()
        {
            Task39.GetDuplicates(new []{ 1 }).Should().BeEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstraintsViolation_Negative()
        {
            Task39.GetDuplicates(new []{ 1, -1 });
        }

        [TestMethod]
        public void NoDuplicates_Positive()
        {
            Task39.GetDuplicates(new[] { 1, 2, 3, 4, 5 }).Should().BeEmpty();
        }

        [TestMethod]
        public void OneDuplicate_Positive()
        {
            Task39.GetDuplicates(new[] { 1, 2, 1, 4, 5 }).Should().BeEquivalentTo(new List<int> { 1 });
        }

        [TestMethod]
        public void SeveralDuplicates_Positive()
        {
            Task39.GetDuplicates(new[] { 4, 3, 2, 2, 3 }).Should().BeEquivalentTo(new List<int> { 2, 3 });
        }
    }
}