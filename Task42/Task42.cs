using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task42
{
    // 42.Give a one-line expression to test whether a number is a power of 2 [No loops allowed - it's a
    // simple test.]
    // Time: O(1)
    // Space: O(1)
    public static class Task42
    {
        public static bool IsPowerOfTwo(int value)
        {
            return value == 1 || value > 1 && (value & (value - 1)) == 0;
        }
    }
}