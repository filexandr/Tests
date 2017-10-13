using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task60
{
    [TestClass]
    public class Task60UnitTest
    {
        [TestMethod]
        public void NullAndEmpty()
        {
            Task60.RandomPermutation(null);
            Task60.RandomPermutation(new int[0]);
        }

        [TestMethod]
        public void One()
        {
            var input = new int[] { 1 };
            var expected = (int[])input.Clone();
            Task60.RandomPermutation(input);
            input.Should().Equal(expected);
        }

        [TestMethod]
        public void Two()
        {
            var input = new int[] {1, 2};
            var notExpected = (int[])input.Clone();
            Task60.RandomPermutation(input);
            input.Should().NotEqual(notExpected);
        }

        [TestMethod]
        public void Three()
        {
            var input = new int[] {1, 2, 3};
            var notExpected = (int[])input.Clone();
            Task60.RandomPermutation(input);
            input.Should().NotEqual(notExpected);
        }

        [TestMethod]
        public void Many()
        {
            var input = new int[] {10, 5, 1, 100, -7, 28, 342, 0, 98, 23, 81, 134};
            var notExpected = (int[])input.Clone();
            Task60.RandomPermutation(input);
            input.Should().NotEqual(notExpected);
        }
    }
}
