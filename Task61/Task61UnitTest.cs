using System.Collections.Generic;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task61
{
    [TestClass]
    public class Task61UnitTest
    {
        [TestMethod]
        public void NullAndEmpty()
        {
            HashSet<int> smallest;
            HashSet<int> largest;
            Task61.FindSmallestAndLargest(null, out smallest, out largest);
            smallest.Should().NotBeNull();
            smallest.Count.Should().Be(0);
            largest.Should().NotBeNull();
            largest.Count.Should().Be(0);

            Task61.FindSmallestAndLargest(new string[0], out smallest, out largest);
            smallest.Should().NotBeNull();
            smallest.Count.Should().Be(0);
            largest.Should().NotBeNull();
            largest.Count.Should().Be(0);

            Task61.FindSmallestAndLargest(new string[] {null, null, null}, out smallest, out largest);
            smallest.Should().NotBeNull();
            smallest.Count.Should().Be(0);
            largest.Should().NotBeNull();
            largest.Count.Should().Be(0);
        }

        [TestMethod]
        public void One()
        {
            HashSet<int> smallest;
            HashSet<int> largest;
            Task61.FindSmallestAndLargest(new [] {"a"}, out smallest, out largest);
            smallest.Should().NotBeNull();
            smallest.Should().BeEquivalentTo(new [] {0});
            largest.Should().NotBeNull();
            largest.Should().BeEquivalentTo(new [] {0});

            Task61.FindSmallestAndLargest(new [] {""}, out smallest, out largest);
            smallest.Should().NotBeNull();
            smallest.Should().BeEquivalentTo(new [] {0});
            largest.Should().NotBeNull();
            largest.Should().BeEquivalentTo(new [] {0});
        }

        [TestMethod]
        public void SeveralEqual()
        {
            HashSet<int> smallest;
            HashSet<int> largest;
            Task61.FindSmallestAndLargest(new [] {"a", "a", "a"}, out smallest, out largest);
            smallest.Should().NotBeNull();
            smallest.Should().BeEquivalentTo(new [] {0, 1, 2});
            largest.Should().NotBeNull();
            largest.Should().BeEquivalentTo(new [] { 0, 1, 2 });

            Task61.FindSmallestAndLargest(new [] {"", "", ""}, out smallest, out largest);
            smallest.Should().NotBeNull();
            smallest.Should().BeEquivalentTo(new [] {0, 1, 2});
            largest.Should().NotBeNull();
            largest.Should().BeEquivalentTo(new [] { 0, 1, 2 });
        }

        [TestMethod]
        public void SeveralNotEqual()
        {
            HashSet<int> smallest;
            HashSet<int> largest;
            Task61.FindSmallestAndLargest(new [] {"ab", "abc", "abcd", "ab", "ad", "abcde", "ad"}, out smallest, out largest);
            smallest.Should().NotBeNull();
            smallest.Should().BeEquivalentTo(new [] {0, 3});
            largest.Should().NotBeNull();
            largest.Should().BeEquivalentTo(new [] { 4, 6 });
        }
    }
}