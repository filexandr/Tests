using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentAssertions;

namespace OnlineTask2
{
    [TestClass]
    public class BinaryTreeUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NullAndEmpty()
        {
            BinaryTree.Create(null);
            BinaryTree.Create(new int[0]);
        }

        [TestMethod]
        public void One()
        {
            var tree = BinaryTree.Create(new int[] { 1 });
            tree.Should().NotBeNull();
            tree.Head.Should().NotBeNull();
            tree.Head.Value.Should().Be(1);

            tree.Head.Left.Should().BeNull();

            tree.Head.Right.Should().BeNull();
        }

        [TestMethod]
        public void Two()
        {
            var tree = BinaryTree.Create(new int[] { 1, 2 });
            tree.Should().NotBeNull();
            tree.Head.Should().NotBeNull();
            tree.Head.Value.Should().Be(2);

            tree.Head.Left.Should().NotBeNull();
            tree.Head.Left.Value.Should().Be(1);

            tree.Head.Right.Should().BeNull();

        }

        [TestMethod]
        public void Three()
        {
            var tree = BinaryTree.Create(new int[] { 1, 2, 3 });
            tree.Should().NotBeNull();
            tree.Head.Should().NotBeNull();
            tree.Head.Value.Should().Be(2);

            tree.Head.Left.Should().NotBeNull();
            tree.Head.Left.Value.Should().Be(1);

            tree.Head.Right.Should().NotBeNull();
            tree.Head.Right.Value.Should().Be(3);
        }
    }
}