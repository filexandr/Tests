using System;

namespace Task43
{
    // 43. Given an array of characters which form a sentence of words,
    // give an efficient algorithm to reverse the order of the words(not characters) in it.
    // Time: the best case O(N), the worst case O(N log W), where W - count of words
    // Space: O(1)
    public static class Task43
    {
        public static void ReverseWords(char[] sentance)
        {
            // [spaces]short[inner part]verylong[spaces] 1. Find 2 outer words
            // [spaces]veryl[inner part]shortong[spaces] 2. Exchange by chars using min word space
            // [spaces]verylong[inner part]short[spaces] 3. Quick rotate by O(2N)
            // 4. Continue from p.1 with inner part

            if (sentance == null || sentance.Length < 3) return;

            const char wordSeparator = ' ';
            int leftWordStart = 0;
            int leftWordLen = 0;
            int rightWordEnd = sentance.Length - 1;
            int rightWordLen = 0;

            while (true)
            {
                // Find left word
                for (int i = leftWordStart + leftWordLen; i < sentance.Length - 1; i++)
                {
                    if (sentance[i] != wordSeparator)
                    {
                        leftWordStart = i;
                        break;
                    }
                }

                leftWordLen = 0;
                for (int i = leftWordStart + 1; i < sentance.Length; i++)
                {
                    if (sentance[i] == wordSeparator)
                    {
                        leftWordLen = i - leftWordStart;
                        break;
                    }
                }

                // Find right word
                for (int i = rightWordEnd - rightWordLen; i > 0; i--)
                {
                    if (sentance[i] != wordSeparator)
                    {
                        rightWordEnd = i;
                        break;
                    }
                }

                rightWordLen = 0;
                for (int i = rightWordEnd - 1; i >= 0; i--)
                {
                    if (sentance[i] == wordSeparator)
                    {
                        rightWordLen = rightWordEnd - i;
                        break;
                    }
                }

                if (leftWordStart >= rightWordEnd - rightWordLen ||
                    sentance[leftWordStart] == wordSeparator ||
                    sentance[rightWordEnd] == wordSeparator)
                {
                    // One or no words left
                    break;
                }

                for (int i = 0; i < Math.Min(leftWordLen, rightWordLen); i++)
                {
                    var leftIndex = leftWordStart + i;
                    var rightIndex = rightWordEnd - rightWordLen + 1 + i;
                    var leftChar = sentance[leftIndex];
                    sentance[leftIndex] = sentance[rightIndex];
                    sentance[rightIndex] = leftChar;
                }

                // [spaces]veryl[inner part]shortong[spaces] 
                if (leftWordLen < rightWordLen)
                {
                    var diff = Math.Abs(leftWordLen - rightWordLen);
                    RotateRight(sentance, leftWordStart + leftWordLen, rightWordEnd, diff);
                    var oldLeftLen = leftWordLen;
                    leftWordLen = rightWordLen;
                    rightWordEnd = oldLeftLen;
                    break;
                }

                // [spaces]shortong[inner part]veryl[spaces] 
                if (leftWordLen > rightWordLen)
                {
                    RotateLeft(sentance, leftWordStart + rightWordLen, rightWordEnd,
                        Math.Abs(leftWordLen - rightWordLen));
                    var oldLeftLen = leftWordLen;
                    leftWordLen = rightWordLen;
                    rightWordEnd = oldLeftLen;
                }
            }
        }

        // Time: O(2N)
        // Space: O(1)
        public static void RotateLeft(char[] array, int start, int end, int count)
        {
            var len = end - start + 1;
            if (count == 0 || count == len) return;
            Array.Reverse(array, start, len);
            Array.Reverse(array, start, len - count);
            Array.Reverse(array, end - count + 1, count);
        }

        // Time: O(2N)
        // Space: O(1)
        public static void RotateRight(char[] array, int start, int end, int count)
        {
            var len = end - start + 1;
            if (count == 0 || count == len) return;
            Array.Reverse(array, start, len);
            Array.Reverse(array, start, count);
            Array.Reverse(array, start + count, len - count);
        }
    }
}