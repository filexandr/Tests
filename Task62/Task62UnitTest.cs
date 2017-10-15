using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentAssertions;

namespace Task62
{
    [TestClass]
    public class Task62UnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null()
        {
            Task62.RemoveDuplicates(null);
        }

        [TestMethod]
        public void Empty()
        {
            Task62.RemoveDuplicates(new int[0]).Should().Be(0);
        }

        [TestMethod]
        public void One()
        {
            Task62.RemoveDuplicates(new int[] {1}).Should().Be(1);
        }

        [TestMethod]
        public void Unique()
        {
            var input = new int[] {1, 2, 3};
            var expected = (int[]) input.Clone();
            Task62.RemoveDuplicates(input).Should().Be(3);
            input.Should().Equal(expected);
        }

        [TestMethod]
        public void Duplicates()
        {
            var input = new int[] {1, 1, 2, 3, 3, 3, 4, 5, 5, 5, 5};
            Task62.RemoveDuplicates(input).Should().Be(5);
            var unique = new int[5];
            Array.Copy(input, unique, 5);
            unique.Should().Equal(new int[] {1, 2, 3, 4, 5});
        }
    }
}
