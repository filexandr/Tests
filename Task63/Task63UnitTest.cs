using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentAssertions;

namespace Task63
{
    [TestClass]
    public class Task63UnitTest
    {
        [TestMethod]
        public void NullAndEmpty()
        {
            Task63.Intersects(null, null).Should().BeFalse();
            Task63.Intersects(new int[0], null).Should().BeFalse();
            Task63.Intersects(null, new int[0]).Should().BeFalse();
            Task63.Intersects(new int[0], new int[0]).Should().BeFalse();
            Task63.Intersects(new int[] {1, 2}, null).Should().BeFalse();
            Task63.Intersects(new int[] {1, 2}, new int[0]).Should().BeFalse();
            Task63.Intersects(null, new int[] {1, 2}).Should().BeFalse();
            Task63.Intersects(new int[0], new int[] {1, 2}).Should().BeFalse();
        }

        [TestMethod]
        public void One()
        {
            Task63.Intersects(new[] { 1 }, new[] { 5 }).Should().BeFalse();
            Task63.Intersects(new[] { 1 }, new[] { 1 }).Should().BeTrue();
        }

        [TestMethod]
        public void Several()
        {
            Task63.Intersects(new[] {1, 1, -10, 5, 100}, new[] {7, 50, 19}).Should().BeFalse();
            Task63.Intersects(new[] {1, 1, -10, 5, 100}, new[] {34, 78, 5, 100}).Should().BeTrue();
        }
    }
}