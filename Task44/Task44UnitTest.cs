using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentAssertions;

namespace Task44
{
    [TestClass]
    public class Task44UnitTest
    {
        [TestMethod]
        public void Null()
        {
            Task44.ReverseLinkedList(null).Should().BeNull();
        }

        [TestMethod]
        public void One()
        {
            var node = new Node {Value = 1};
            Task44.ReverseLinkedList(node).Should().Equals(node);
        }

        [TestMethod]
        public void Several()
        {
            var node = new Node() { Value = 1, Next = new Node { Value = 2, Next = new Node { Value = 3 } } };
            var result = Task44.ReverseLinkedList(node);
            result.Should().NotBeNull();
            result.Value.Should().Equals(3);

            result.Next.Should().NotBeNull();
            result.Next.Value.Should().Equals(2);

            result.Next.Next.Should().NotBeNull();
            result.Next.Next.Value.Should().Equals(1);
            result.Next.Next.Next.Should().BeNull();
        }
    }
}