using System;

namespace Task57
{
    // 57. Sort an array of size n containing integers between 1 and K, given a temporary scratch integer
    // array of size K.
    // Time: O(n)
    // Space: O(k)
    public static class Task57
    {
        public static void SortArray(int[] input, int k)
        {
            if (input == null || input.Length <= 2) return;

            if (k < 1) throw new ArgumentException("K must be more than 0");

            var tempArray = new int[k];
            for (int i = 0; i < input.Length; i++)
            {
                var value = input[i];
                if (value < 1 || value > k) throw new Exception($"Array must contain values between 1 and {k}, but found {value} at position {i}.");
                tempArray[value - 1]++;
            }

            int outIndex = 0;
            for (int i = 0; i < tempArray.Length; i++)
            {
                var count = tempArray[i];
                for (int j = 0; j < count; j++)
                {
                    input[outIndex] = i + 1;
                    outIndex++;
                }
            }
        }
    }
}