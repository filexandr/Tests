using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentAssertions;

namespace Task67
{
    [TestClass]
    public class Task67UnitTest
    {
        [TestMethod]
        public void Test()
        {
            Task67.FindMiddle(null).Should().BeNull();

            var list = new Node(1);
            Task67.FindMiddle(list).Should().Be(list);

            list = new Node(1);
            list.CreateNext(2);
            Task67.FindMiddle(list).Should().Be(list.Next);

            list = new Node(1);
            list.CreateNext(2).CreateNext(3);
            Task67.FindMiddle(list).Should().Be(list.Next);

            list = new Node(1);
            list.CreateNext(2).CreateNext(3).CreateNext(4);
            Task67.FindMiddle(list).Should().Be(list.Next.Next);

            list = new Node(1);
            list.CreateNext(2).CreateNext(3).CreateNext(4).CreateNext(5);
            Task67.FindMiddle(list).Should().Be(list.Next.Next);
        }
    }
}