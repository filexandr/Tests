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
            _list.Head.Should().Equals(node);
            _list.Head.Next.Should().BeNull();

            node = new Node(1);
            _list.AddLast(node);
            _list.Head.Value.Should().Equals(0);
            _list.Head.Next.Should().Equals(node);

            node = new Node(2);
            _list.AddLast(node);
            _list.Head.Value.Should().Equals(0);
            _list.Head.Next.Value.Should().Equals(1);
            _list.Head.Next.Next.Should().Equals(node);
        }

        [TestMethod]
        public void AddAtIndex()
        {
            _list.Head.Should().BeNull();

            // 0
            var node = new Node(0);
            _list.AddAtIndex(node, 0);
            _list.Head.Should().Equals(node);

            // 1 0
            node = new Node(1);
            _list.AddAtIndex(node, 0);
            _list.Head.Should().Equals(node);
            _list.Head.Next.Value.Should().Equals(0);

            // 1 2 0
            node = new Node(2);
            _list.AddAtIndex(node, 1);
            _list.Head.Next.Should().Equals(node);
            _list.Head.Value.Should().Equals(1);
            _list.Head.Next.Next.Value.Should().Equals(0);
        }

        [TestMethod]
        public void Delete()
        {
            _list.Head.Should().BeNull();

            // 0 1 2
            _list.AddLast(new Node(0));
            _list.AddLast(new Node(1));
            _list.AddLast(new Node(2));

            // 1 2
            _list.Delete(0);
            _list.Head.Value.Should().Equals(1);
            _list.Head.Next.Value.Should().Equals(2);
            _list.Head.Next.Next.Should().BeNull();

            // 1
            _list.Delete(1);
            _list.Head.Value.Should().Equals(1);
            _list.Head.Next.Should().BeNull();
        }
    }
}