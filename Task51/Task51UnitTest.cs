using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentAssertions;

namespace Task51
{
    [TestClass]
    public class Task51UnitTest
    {
        [TestMethod]
        public void NullAndEmpty()
        {
            Task51.DeleteOccurrences(null, null).Should().BeNull();
            Task51.DeleteOccurrences(string.Empty, null).Should().BeNull();
            Task51.DeleteOccurrences(string.Empty, string.Empty).Should().BeEmpty();
            Task51.DeleteOccurrences(null, string.Empty).Should().BeEmpty();
            Task51.DeleteOccurrences(null, "Hello").Should().Be("Hello");
            Task51.DeleteOccurrences(string.Empty, "Hello").Should().Be("Hello");
        }

        [TestMethod]
        public void RemoveAll()
        {
            Task51.DeleteOccurrences("Hello", "Hello").Should().BeEmpty();
        }

        [TestMethod]
        public void RemovePart()
        {
            Task51.DeleteOccurrences("Hello", "House was built from raw logs.").Should().Be("us was buit frm raw gs.");
        }
    }
}
