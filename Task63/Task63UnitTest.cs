using System;

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
            Task63.Intersects(new Node(0), null).Should().BeFalse();
            Task63.Intersects(null, new Node(0)).Should().BeFalse();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void List1IsCyclical_Negative()
        {
            var list1 = new Node(11);
            list1.Next = list1;
            var list2 = new Node(21);
            Task63.Intersects(list1, list2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void List2IsCyclical_Negative()
        {
            var list1 = new Node(11);
            var list2 = new Node(21);
            list2.Next = list2;
            Task63.Intersects(list1, list2);
        }

        [TestMethod]
        public void One()
        {   
            Task63.Intersects(new Node(0), new Node(0)).Should().BeFalse();

            var node = new Node(0);
            Task63.Intersects(node, node).Should().BeTrue();
        }

        [TestMethod]
        public void Several()
        {
            var list1 = new Node(11);
            list1.CreateNext(12).CreateNext(13);
            var list2 = new Node(21);
            list1.CreateNext(22).CreateNext(23);
            Task63.Intersects(list1, list2).Should().BeFalse();

            list1 = new Node(11);
            list1.CreateNext(12).CreateNext(13);
            list2 = new Node(21);
            list1.CreateNext(22).CreateNext(23);
            list1.Next.Next.Next = list2;
            Task63.Intersects(list1, list2).Should().BeTrue();
        }
    }
}