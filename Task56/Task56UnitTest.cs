using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentAssertions;

namespace Task56
{
    [TestClass]
    public class Task56UnitTest
    {
        [TestMethod]
        public void NullAndEmpty()
        {
            Task56.ExtractUniqueElements(null).Should().BeNull();
            Task56.ExtractUniqueElements(new int[0]).Should().BeNull();
        }

        [TestMethod]
        public void One()
        {
            Task56.ExtractUniqueElements(new int[1] { 1 }).Should().Equal(new int[] { 1 });
        }

        [TestMethod]
        public void SeveralTheSame()
        {
            Task56.ExtractUniqueElements(new int[] { 1, 1, 1, 1, 1 }).Should().Equal(new int[] { 1 });
        }

        [TestMethod]
        public void SeveralDifferent()
        {
            Task56.ExtractUniqueElements(new int[] { 1, 1, 2, 3, 3, 3 }).Should().Equal(new int[] { 1, 2, 3 });
        }
    }
}