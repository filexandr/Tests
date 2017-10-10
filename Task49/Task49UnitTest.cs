using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentAssertions;

namespace Task49
{
    [TestClass]
    public class Task49UnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HeadNull()
        {
            Task49.Delete(null, new Node());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteNull()
        {
            Task49.Delete(new Node(), null);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void UnknownElement()
        {
            Task49.Delete(new Node(), new Node());
        }

        [TestMethod]
        public void Singe()
        {
            var node = new Node();
            Task49.Delete(node, node).Should().BeNull();
        }

        [TestMethod]
        public void Fisrt()
        {
            var node1 = new Node {Value = 1};
            var node2 = new Node { Value = 2 };
            node1.Next = node2;

            var head = Task49.Delete(node1, node1);
            head.Should().NotBeNull();
            head.Next.Should().BeNull();
            head.Previous.Should().BeNull();
            head.Value.Should().Be(2);
        }

        [TestMethod]
        public void Last()
        {
            var node1 = new Node { Value = 1 };
            var node2 = new Node { Value = 2 };
            node1.Next = node2;

            var head = Task49.Delete(node1, node2);
            head.Should().NotBeNull();
            head.Next.Should().BeNull();
            head.Previous.Should().BeNull();
            head.Value.Should().Be(1);
        }

        [TestMethod]
        public void Middle()
        {
            var node1 = new Node { Value = 1 };
            var node2 = new Node { Value = 2 };
            var node3 = new Node { Value = 3 };
            node1.Next = node2;
            node2.Next = node3;

            var head = Task49.Delete(node1, node2);
            head.Should().NotBeNull();
            head.Value.Should().Be(1);
            head.Next.Should().NotBeNull();
            head.Next.Value.Should().Be(3);
            head.Next.Next.Should().BeNull();
        }
    }
}