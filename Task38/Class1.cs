using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task38
{
    public static class Test
    {
        public static int[] ArrayPow2(int[] input)
        {
            if (input == null) return null;
            // TODO validate on input sorting

            int cur1 = 0;
            int cur2 = input.Length - 1;
            var output = new int[input.Length];
            int curOut = cur2;
            while (cur1 <= cur2)
            {
                int value1 = input[cur1];
                value1 *= value1;

                if (cur1 == cur2)
                {
                    output[curOut] = value1;
                    break;
                }

                int value2 = input[cur2];
                value2 *= value2;

                if (value1 >= value2)
                {
                    output[curOut] = value1;
                    curOut--;
                    cur1++;
                }

                if (value1 <= value2)
                {
                    output[curOut] = value2;
                    curOut--;
                    cur2--;
                }
            }

            return output;
        }
    }

    [TestClass]
    public class ArrayPow2UnitTest
    {
        [TestMethod]
        public void Null()
        {
            var actual = Test.ArrayPow2(null);
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void One()
        {
            var input = new int[] { 2 };
            var actual = Test.ArrayPow2(input);
            actual.Should().Equal(new int[] { 4 });
        }

        [TestMethod]
        public void AllNegatives()
        {
            var input = new int[] { -3, -2, -1 };
            var actual = Test.ArrayPow2(input);
            actual.Should().Equal(new int[] { 1, 4, 9 });
        }

        [TestMethod]
        public void AllPositivesAndEvenCount()
        {
            var input = new int[] { 0, 1, 3, 5 };
            var actual = Test.ArrayPow2(input);
            actual.Should().Equal(new int[] { 0, 1, 9, 25 });
        }

        [TestMethod]
        public void MixedAndOddCount()
        {
            var input = new int[] { -3, -2, -1, 0, 1, 3, 5 };
            var actual = Test.ArrayPow2(input);
            actual.Should().Equal(new int[] { 0, 1, 1, 4, 9, 9, 25 });
        }
    }
}
