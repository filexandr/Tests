using System;
using System.Collections;

namespace Task58
{
    // 58.Given an array of length N containing integers between 1 and N, determine if it contains any
    // duplicates
    // Time: O(n)
    // Space: O(n)
    public static class Task58
    {
        public static bool ContainDuplicates(int[] input)
        {
            if (input == null || input.Length < 2) return false;

            var vector = new BitArray(input.Length);
            foreach (var item in input)
            {
                if (item < 1 || item > input.Length)
                {
                    throw new ArgumentException($"All values must be in range 1..{input.Length} but found {item}.");
                }

                if (vector.Get(item - 1)) return true;
                vector.Set(item - 1, true);
            }

            return false;
        }
    }
}