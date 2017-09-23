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
        public void Null()
        {
            Task49.Delete(null, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void OutOfRange()
        {
            Task49.Delete(new Node(), -1);
        }

        [TestMethod]
        public void Singe()
        {
            Task49.Delete(new Node(), 0).Should().BeNull();
            Task49.Delete(new Node(), 1).Should().BeNull();
        }

        [TestMethod]
        public void Fisrt()
        {
            var head = Task49.Delete(new Node {Value = 1, Next = new Node {Value = 2} }, 0);
            head.Should().NotBeNull();
            head.Next.Should().BeNull();
            head.Previous.Should().BeNull();
            head.Value.Should().Be(2);
        }

        [TestMethod]
        public void Last()
        {
            var head = Task49.Delete(new Node {Value = 1, Next = new Node {Value = 2} }, 1);
            head.Should().NotBeNull();
            head.Next.Should().BeNull();
            head.Previous.Should().BeNull();
            head.Value.Should().Be(1);
        }

        [TestMethod]
        public void Middle()
        {
            var head = Task49.Delete(new Node {Value = 1, Next = new Node {Value = 2, Next = new Node {Value = 3} } }, 1);
            head.Should().NotBeNull();
            head.Value.Should().Be(1);

            head.Next.Should().NotBeNull();
            head.Next.Value.Should().Be(3);

            head.Next.Next.Should().BeNull();
        }
    }
}