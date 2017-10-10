using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentAssertions;

namespace Task47
{
    [TestClass]
    public class Task47UnitTest
    {
        private LinkedList _list;

        [TestInitialize]
        public void TestInit()
        {
            _list = new LinkedList();
        }

        [TestMethod]
        public void AddLast()
        {
            _list.Head.Should().BeNull();

            var node = new Node(0);
            _list.AddLast(node);
            _list.Head.Should().Be(node);
            _list.Head.Next.Should().BeNull();

            node = new Node(1);
            _list.AddLast(node);
            _list.Head.Value.Should().Be(0);
            _list.Head.Next.Should().Be(node);

            node = new Node(2);
            _list.AddLast(node);
            _list.Head.Value.Should().Be(0);
            _list.Head.Next.Value.Should().Be(1);
            _list.Head.Next.Next.Should().Be(node);
        }

        [TestMethod]
        public void AddAtIndex()
        {
            _list.Head.Should().BeNull();

            // 0
            var node = new Node(0);
            _list.AddAtIndex(node, 0);
            _list.Head.Should().Be(node);

            // 1 0
            node = new Node(1);
            _list.AddAtIndex(node, 0);
            _list.Head.Should().Be(node);
            _list.Head.Next.Value.Should().Be(0);

            // 1 2 0
            node = new Node(2);
            _list.AddAtIndex(node, 1);
            _list.Head.Next.Should().Be(node);
            _list.Head.Value.Should().Be(1);
            _list.Head.Next.Next.Value.Should().Be(0);
        }

        [TestMethod]
        public void DeleteByIndex()
        {
            _list.Head.Should().BeNull();

            // 0 1 2
            _list.AddLast(new Node(0));
            _list.AddLast(new Node(1));
            _list.AddLast(new Node(2));

            // 1 2
            _list.Delete(0);
            _list.Head.Value.Should().Be(1);
            _list.Head.Next.Value.Should().Be(2);
            _list.Head.Next.Next.Should().BeNull();

            // 1
            _list.Delete(1);
            _list.Head.Value.Should().Be(1);
            _list.Head.Next.Should().BeNull();

            // empty
            _list.Delete(0);
            _list.Head.Should().BeNull();
        }

        [TestMethod]
        public void DeleteByValue()
        {
            _list.Head.Should().BeNull();

            // 0 1 2
            var node0 = new Node(0);
            var node1 = new Node(1);
            var node2 = new Node(2);
            _list.AddLast(node0);
            _list.AddLast(node1);
            _list.AddLast(node2);

            // 1 2
            _list.Delete(node0);
            _list.Head.Value.Should().Be(1);
            _list.Head.Next.Value.Should().Be(2);
            _list.Head.Next.Next.Should().BeNull();

            // 1
            _list.Delete(node2);
            _list.Head.Value.Should().Be(1);
            _list.Head.Next.Should().BeNull();

            // empty
            _list.Delete(node1);
            _list.Head.Should().BeNull();
        }
    }
}