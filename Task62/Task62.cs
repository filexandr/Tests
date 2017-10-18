using System;
using System.Collections;

namespace Task62
{
    // 62.Write a program to remove duplicates from a sorted array.
    // Time: O(n)
    // Space: O(1)
    public static class Task62
    {
        // It performs removing inplace and returns number of unique values.
        public static int RemoveDuplicates(int[] input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            if (input.Length < 2) return input.Length;

            var lastUniqueIndex = 0;

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] != input[lastUniqueIndex])
                {
                    if (i - lastUniqueIndex > 1)
                    {
                        lastUniqueIndex++;
                        input[lastUniqueIndex] = input[i];
                    }
                    else
                    {
                        lastUniqueIndex = i;
                    }
                }
            }

            return lastUniqueIndex + 1;
        }
    }
}