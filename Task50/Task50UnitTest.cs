using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentAssertions;

namespace Task50
{
    [TestClass]
    public class Task50UnitTest
    {
        [TestMethod]
        public void Null()
        {
            Task50.DepthRecursion(null).Should().Be(0);
            Task50.DepthIterative(null).Should().Be(0);
        }

        [TestMethod]
        public void One()
        {
            int[] array = { 1 };
            var tree = Task50.Create(array);
            Task50.DepthRecursion(tree).Should().Be(1);
            Task50.DepthIterative(tree).Should().Be(1);
        }

        [TestMethod]
        public void Two()
        {
            int[] array = { 1, 2 };
            var tree = Task50.Create(array);
            Task50.DepthRecursion(tree).Should().Be(2);
            Task50.DepthIterative(tree).Should().Be(2);
        }

        [TestMethod]
        public void Three()
        {
            int[] array = { 1, 2, 3, 4 };
            var tree = Task50.Create(array);
            Task50.DepthRecursion(tree).Should().Be(3);
            Task50.DepthIterative(tree).Should().Be(3);
        }

        [TestMethod]
        public void Seven()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7  };
            var tree = Task50.Create(array);
            Task50.DepthRecursion(tree).Should().Be(3);
            Task50.DepthIterative(tree).Should().Be(3);
        }
    }
}