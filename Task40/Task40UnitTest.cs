using System;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentAssertions;

namespace Task40
{
    [TestClass]
    public class Task40UnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IntSqrt_Negative()
        {
            Task40.IntSqrt(-1);
        }

        [TestMethod]
        public void IntSqrt_Positive()
        {
            Task40.IntSqrt(0).Should().Equals(0);
            Task40.IntSqrt(1).Should().Equals(1);
            Task40.IntSqrt(2).Should().Equals(1);
            Task40.IntSqrt(3).Should().Equals(2);
            Task40.IntSqrt(4).Should().Equals(2);
            Task40.IntSqrt(5).Should().Equals(2);
            Task40.IntSqrt(6).Should().Equals(2);
            Task40.IntSqrt(7).Should().Equals(3);
            Task40.IntSqrt(8).Should().Equals(3);
            Task40.IntSqrt(9).Should().Equals(3);
            Task40.IntSqrt(10).Should().Equals(3);
            Task40.IntSqrt(11).Should().Equals(3);
            Task40.IntSqrt(12).Should().Equals(3);
            Task40.IntSqrt(13).Should().Equals(4);
            Task40.IntSqrt(14).Should().Equals(4);
            Task40.IntSqrt(15).Should().Equals(4);
            Task40.IntSqrt(16).Should().Equals(4);
            Task40.IntSqrt(17).Should().Equals(4);
            Task40.IntSqrt(18).Should().Equals(4);
            Task40.IntSqrt(19).Should().Equals(4);
            Task40.IntSqrt(20).Should().Equals(4);
            Task40.IntSqrt(21).Should().Equals(5);
            Task40.IntSqrt(22).Should().Equals(5);
            Task40.IntSqrt(23).Should().Equals(5);
            Task40.IntSqrt(24).Should().Equals(5);
            Task40.IntSqrt(25).Should().Equals(5);
            Task40.IntSqrt(26).Should().Equals(5);
            Task40.IntSqrt(27).Should().Equals(5);
            Task40.IntSqrt(28).Should().Equals(5);
            Task40.IntSqrt(29).Should().Equals(5);
            Task40.IntSqrt(30).Should().Equals(5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Circle_Negative()
        {
            Task40.CalcCirclePoints(10, 10, -5);
        }

        [TestMethod]
        public void Circle_Positive()
        {
            var points = Task40.CalcCirclePoints(10, 10, 5);
            points.Should().NotBeNull();
            points.Length.Should().Equals(6 * 4);
            points.All(point => point.X >= -15 && point.X <= 15 && point.Y >= -15 && point.Y <= 15).Should().BeTrue();
            points.All(point => Math.Sqrt(Math.Pow(Math.Abs(point.X - 10), 2) + Math.Pow(Math.Abs(point.Y - 10), 2)) <= 6).Should().BeTrue();
            points.All(point => Math.Sqrt(Math.Pow(Math.Abs(point.X - 10), 2) + Math.Pow(Math.Abs(point.Y - 10), 2)) >= 4).Should().BeTrue();
        }
    }
}