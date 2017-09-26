using System;

namespace Task53
{
    // 53. Write a routine that prints out a 2-D array in spiral order
    // Time: O(N)
    // Space: O(1)
    public static class Task53
    {
        public static void PrintArrayInSpiralOrder(int[,] inputArray)
        {
            if (inputArray == null) return;

            int yLen = inputArray.GetUpperBound(0) + 1;
            int xLen = inputArray.GetUpperBound(1) + 1;

            if (xLen == 0 && yLen == 0) return;

            int x = 0;
            int y = 0;
            int xInc = 1;
            int yInc = 0;
            int processed = 0;
            int resultLen = xLen * yLen;
            int cycle = 0;

            while (processed < resultLen)
            {
                var value = inputArray[y, x];
                Console.Write($" {value}");
                processed++;

                if (xInc == 1)
                {
                    x++;
                    if (x == xLen - 1 - cycle)
                    {
                        xInc = 0;
                        yInc = 1;
                    }
                }
                else if (xInc == -1)
                {
                    x--;
                    if (x == cycle)
                    {
                        xInc = 0;
                        yInc = -1;
                    }
                }
                else if (yInc == 1)
                {
                    y++;
                    if (y == yLen - 1 - cycle)
                    {
                        yInc = 0;
                        xInc = -1;
                    }
                }
                else if (yInc == -1)
                {
                    y--;
                    if (y == cycle + 1)
                    {
                        yInc = 0;
                        xInc = 1;
                        cycle++;
                    }
                }
            }
        }
    }
}