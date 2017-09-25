using System;
using System.Text;

namespace Task51
{
    // 51.Given two strings S1 and S2.Delete from S2 all those characters which occur in S1 also and finally
    // create a clean S2 with the relevant characters deleted.
    // Time: O(N1 + N2)
    // Space: O(C + N2) where C - count of available chars
    public static class Task51
    {
        public static string DeleteOccurrences(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2)) return s2;

            var charVector = new bool[Char.MaxValue];
            for (int i = 0; i < s1.Length; i++)
            {
                charVector[s1[i]] = true;
            }

            var result = new StringBuilder(s2.Length);
            for (int i = 0; i < s2.Length; i++)
            {
                if (!charVector[s2[i]]) result.Append(s2[i]);
            }

            return result.ToString();
        }
    }
}