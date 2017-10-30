using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentAssertions;

namespace OnlineTask4
{
    [TestClass]
    public class OnlineTask4UnitTest
    {
        [TestMethod]
        public void Test()
        {
            OnlineTask4.GetSumPairsCount(null, 1).Should().Be(0);
            OnlineTask4.GetSumPairsCount(new int[0], 1).Should().Be(0);
            OnlineTask4.GetSumPairsCount(new [] {1}, 1).Should().Be(0);
            OnlineTask4.GetSumPairsCount(new [] {1, 1}, 2).Should().Be(1);
            OnlineTask4.GetSumPairsCount(new[] {-10, 0, 5, 10}, 5).Should().Be(3);
            OnlineTask4.GetSumPairsCount(new[] {0, 0, 0, 0}, 1).Should().Be(0);
            OnlineTask4.GetSumPairsCount(new[] {0, 0, 1, 2}, 4).Should().Be(0);
            OnlineTask4.GetSumPairsCount(new[] {1, 2, 2, 3, 4, 5}, 4).Should().Be(13);
        }
    }
}