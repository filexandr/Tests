using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentAssertions;

namespace Task64
{
    [TestClass]
    public class Task64UnitTest
    {
        [TestMethod]
        public void Null()
        {
            Task64.IsCycled(null).Should().BeFalse();
        }

        [TestMethod]
        public void One()
        {
            Task64.IsCycled(new Node(1)).Should().BeFalse();
        }

        [TestMethod]
        public void NotCycled()
        {
            Task64.IsCycled(new Node(1).CreateNext(2).CreateNext(3)).Should().BeFalse();
        }

        [TestMethod]
        public void CycledOdd()
        {
            var headNode = new Node(1);
            headNode.CreateNext(2).CreateNext(3).Next = headNode;
            Task64.IsCycled(headNode).Should().BeTrue();
        }

        [TestMethod]
        public void CycledEven()
        {
            var headNode = new Node(1);
            headNode.CreateNext(2).CreateNext(3).CreateNext(4).Next = headNode;
            Task64.IsCycled(headNode).Should().BeTrue();
        }
    }
}