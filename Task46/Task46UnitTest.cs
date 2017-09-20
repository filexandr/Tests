using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task46
{
    [TestClass]
    public class Task46UnitTest
    {
        [TestMethod]
        public void Tests()
        {
            for (int i = -100; i <= 100; i++)
            {
                Task46.FastMultiplyBy7(i).Should().Equals(i * 7);
            }
        }
    }
}
