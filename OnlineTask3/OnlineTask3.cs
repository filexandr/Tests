using System;
using System.Collections.Generic;

namespace OnlineTask3
{
    // Given an array with random integer numbers find a minimum number which is not present in array.For example, { -1, 3, 5, -17, 25}
    // the answer is -16, { -1, -15, 3, 5, -17, -16, 25 } = > { -17, -16, -15, -1, 3, 5, 25 } = > -14
    // Time: O(n)
    // Space: O(n)
    public static class OnlineTask3
    {
        public static int GetMinimumNotPresent(int[] input)
        {
            if (input == null || input.Length == 0) throw new ArgumentException("Input must not be null or empty");

            var hash = new HashSet<int>();
            var min = int.MaxValue;
            var max = int.MinValue;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] < min) min = input[i];
                if (input[i] > max) max = input[i];
                hash.Add(input[i]);
            }

            for (int i = min; i < max; i++)
            {
                if (!hash.Contains(i)) return i;
            }

            if (max < Int32.MaxValue) return max + 1;
            if (min == int.MinValue) throw new Exception("Can't provide result less than int.MinValue");
            return min - 1;
        }
    }
}