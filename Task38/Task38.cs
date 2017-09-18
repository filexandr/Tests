using System;

namespace Task38
{
    public static class Task38
    {
        // 38.Given an array containing both positive and negative integers and required to find the sub-array
        // with the largest sum(O(N)).
        // Time: O(N)
        // Space: O(1)
        public static int[] GetSubArrayWithLargestSum(int[] input)
        {
            if (input == null || input.Length == 1) return input;

            int maxStart;
            int maxLen;
            long maxSum;

            var curStart = maxStart = 0;
            var curLen = maxLen = 1;
            var curSum = maxSum = input[0];

            for (var i = 1; i < input.Length; i++)
            {
                // Walking within negatives or zero
                if (curLen == 1 && curSum <= 0 && input[i] > curSum)
                {
                    curSum = input[i];
                    curStart = i;
                    if (curSum > maxSum)
                    {
                        maxStart = curStart;
                        maxLen = curLen;
                        maxSum = curSum;
                    }

                    continue;
                }

                var oldSum = curSum;
                curSum += input[i];

                // Left sum is compensated - it has no influence on max sum anymore
                if (curSum <= 0)
                {
                    curSum = input[i];
                    curStart = i;
                    curLen = 1;
                    continue;
                }

                if (curSum <= oldSum) continue;

                // Grow, max can be overridden
                curLen = i - curStart + 1;
                if (curSum > maxSum)
                {
                    maxStart = curStart;
                    maxLen = curLen;
                    maxSum = curSum;
                }
            }

            var result = new int[maxLen];
            Array.Copy(input, maxStart, result, 0, maxLen);
            return result;
        }
    }
}