using System;

namespace Task41
{
    // 41.Given an integer, write a routine that prints out an chars array.
    // Time: O(N) where N - digit count including sign
    // Space: O(N) where N - digit count including sign
    public static class Task41
    {
        public static string IntToStr(int value)
        {
            var result = string.Empty;
            bool sign = value < 0;

            while (true)
            {
                var remainder = value % 10;
                var intPart = value / 10;
                result = (char)((int) '0' + Math.Abs(remainder)) + result;
                if (intPart == 0)
                {
                    if (sign) result = "-" + result;
                    return result;
                }

                value = (value - remainder) / 10;
            }
        }
    }
}