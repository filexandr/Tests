using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task60
{
    // 60. An array of integers of size n.Generate a random permutation of the array, given a function
    // rand_n() that returns an integer between 1 and n, both inclusive, with equal probability.What is the
    // expected time of your algorithm?    // Time: O(2n)    // Space: O(n)    public static class Task60
    {
        private static readonly Random _random = new Random();

        private static int rand_n(int n)
        {
            return _random.Next(1, n + 1);
        }

        public static void RandomPermutation(int[] input)
        {
            if (input == null || input.Length < 2) return;

            var set = new HashSet<int>();
            for (int i = 0; i < input.Length; i++)
            {
                set.Add(i);
            }

            while (set.Count > 0)
            {
                var leftIndex = rand_n(input.Length) - 1;
                if (!set.Contains(leftIndex)) leftIndex = set.First();
                set.Remove(leftIndex);

                var rightIndex = rand_n(input.Length) - 1;
                if (set.Count > 0)
                {
                    if (!set.Contains(rightIndex)) rightIndex = set.First();
                    set.Remove(rightIndex);
                }
                else if (rightIndex == leftIndex)
                {
                    rightIndex += rightIndex < input.Length - 1 ? 1 : -1;
                }

                var leftValue = input[leftIndex];
                input[leftIndex] = input[rightIndex];
                input[rightIndex] = leftValue;
            }
        }
    }
}