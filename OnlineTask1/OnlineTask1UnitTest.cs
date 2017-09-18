using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OnlineTask1
{
    [TestClass]
    public class OnlineTask1UnitTest
    {
        [TestMethod]
        public void Null()
        {
            var actual = OnlineTask1.ArrayPow2(null);
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void One()
        {
            var input = new int[] { 2 };
            var actual = OnlineTask1.ArrayPow2(input);
            actual.Should().Equal(new int[] { 4 });
        }

        [TestMethod]
        public void AllNegatives()
        {
            var input = new int[] { -3, -2, -1 };
            var actual = OnlineTask1.ArrayPow2(input);
            actual.Should().Equal(new int[] { 1, 4, 9 });
        }

        [TestMethod]
        public void AllPositivesAndEvenCount()
        {
            var input = new int[] { 0, 1, 3, 5 };
            var actual = OnlineTask1.ArrayPow2(input);
            actual.Should().Equal(new int[] { 0, 1, 9, 25 });
        }

        [TestMethod]
        public void MixedAndOddCount()
        {
            var input = new int[] { -3, -2, -1, 0, 1, 3, 5 };
            var actual = OnlineTask1.ArrayPow2(input);
            actual.Should().Equal(new int[] { 0, 1, 1, 4, 9, 9, 25 });
        }
    }
}