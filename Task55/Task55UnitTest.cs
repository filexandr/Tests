using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task55
{
    [TestClass]
    public class Task55UnitTest
    {
        [TestMethod]
        public void NullAndEmpty()
        {
            // Should not raise an exception
            Task55.ToUpper(null);
            Task55.ToUpper(new char[0]);
        }

        [TestMethod]
        public void English()
        {
            var input = "Hello My Friends!".ToCharArray();
            Task55.ToUpper(input);
            input.Should().Equal("HELLO MY FRIENDS!");
        }

        [TestMethod]
        public void Russian()
        {
            var input = "Привет Мои Друзья!".ToCharArray();
            Task55.ToUpper(input);
            input.Should().Equal("ПРИВЕТ МОИ ДРУЗЬЯ!");
        }
    }
}