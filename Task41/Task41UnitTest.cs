using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task41
{
    [TestClass]
    public class Task41UnitTest
    {
        [TestMethod]
        public void Min()
        {
            Task41.IntToStr(int.MinValue).Should().Equals(int.MinValue.ToString());
        }

        [TestMethod]
        public void Zero()
        {
            Task41.IntToStr(0).Should().Equals("0");
        }

        [TestMethod]
        public void Max()
        {
            Task41.IntToStr(int.MaxValue).Should().Equals(int.MaxValue.ToString());
        }
    }
}