using System;

namespace Task59
{
    // 59.An array of integers.The sum of the array is known not to overflow an integer. Compute the sum.
    // What if we know that integers are in 2's complement form?    // Time: O(32*n)    // Space: O(1)    public static class Task59
    {
        public static int CalcSum(int[] input)
        {
            if (input == null || input.Length == 0) throw new ArgumentException("Input is empty.");

            int result = 0;
            int bitValue = 1;
            var bitCount = 0;
            for (int bit = 0; bit < 32; bit++)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    bitCount += (input[i] & bitValue) == bitValue ? 1 : 0;
                }

                if (bitCount % 2 != 0) result |= bitValue;
                bitCount /= 2;
                bitValue *= 2;
            }

            return result;
        }
    }
}