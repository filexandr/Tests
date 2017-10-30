using System;

namespace OnlineTask4
{
    // Given a sorted array and the number, find the number of sum of 2 numbers from array greater than or equal to the given number
    // Time: O(n)
    // Space: O(1)
    public static class OnlineTask4
    {
        public static int GetSumPairsCount(int[] input, int target)
        {
            if (input == null || input.Length < 2) return 0;

            int result = 0;

            int bigIndex;
            int bigDelta;

            int smallIndex;
            int smallDelta;

            if (input[0] > input[input.Length - 1])
            {
                bigIndex = 0;
                bigDelta = 1;
                smallIndex = input.Length - 1;
                smallDelta = -1;
            }
            else
            {
                bigIndex = input.Length - 1;
                bigDelta = -1;
                smallIndex = 0;
                smallDelta = 1;
            }

            while (bigIndex != smallIndex)
            {
                while (input[bigIndex] + input[smallIndex] < target)
                {
                    smallIndex += smallDelta;
                    if (smallIndex == bigIndex) return result;
                }

                result += Math.Abs(bigIndex - smallIndex);
                bigIndex += bigDelta;
            }

            return result;
        }
    }
}