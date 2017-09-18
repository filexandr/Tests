using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentAssertions;

namespace Task38
{
    [TestClass]
    public class Task38UnitTest
    {
        [TestMethod]
        public void Null()
        {
            Task38.GetSubArrayWithLargestSum(null).Should().BeNull();
        }

        [TestMethod]
        public void OneElement()
        {
            var input = new int[] { -1 };
            Task38.GetSubArrayWithLargestSum(input).Should().Equal(new int[] { -1 });
        }

        [TestMethod]
        public void AllNegatives()
        {
            var input = new int[] { -7, -10, -5, -100, -1  };
            Task38.GetSubArrayWithLargestSum(input).Should().Equal(new int[] {-1});
        }

        [TestMethod]
        public void NegativesWithZero()
        {
            var input = new int[] { -7, 0, -10, -100, 0 };
            Task38.GetSubArrayWithLargestSum(input).Should().Equal(new int[] { 0 });
        }

        [TestMethod]
        public void NegativesWithOnePositive()
        {
            var input = new int[] { -7, -10, 10, -100, -1 };
            Task38.GetSubArrayWithLargestSum(input).Should().Equal(new int[] { 10 });
        }

        [TestMethod]
        public void AllZero()
        {
            var input = new int[] { 0, 0, 0, 0, 0  };
            Task38.GetSubArrayWithLargestSum(input).Should().Equal(new int[] {0});
        }

        [TestMethod]
        public void WithZeroTrails()
        {
            var input = new int[] { 0, 0, 1, 0, 0  };
            Task38.GetSubArrayWithLargestSum(input).Should().Equal(new int[] {1});
        }

        [TestMethod]
        public void AllPositives()
        {
            var input = new int[] { 1, 2, 3 };
            Task38.GetSubArrayWithLargestSum(input).Should().Equal(new int[] { 1, 2, 3 });
        }

        [TestMethod]
        public void Mixed1()
        {
            var input = new int[] { 4, -1, 2, 3 };
            Task38.GetSubArrayWithLargestSum(input).Should().Equal(new int[] { 4, -1, 2, 3 });
        }

        [TestMethod]
        public void Mixed2()
        {
            var input = new int[] { 4, -5, 2, 3, -1, 1, 0 };
            Task38.GetSubArrayWithLargestSum(input).Should().Equal(new int[] { 2, 3 });
        }

        [TestMethod]
        public void Mixed3()
        {
            var input = new int[] { 10, -5, -1, 3, 1000, -10, -2000, 0, 1000, 5 };
            Task38.GetSubArrayWithLargestSum(input).Should().Equal(new int[] { 10, -5, -1, 3, 1000 });
        }
    }
}