using System;
using System.Drawing;

namespace Task40
{
    public static class Task40
    {
        // TODO apply comments
        // задача 40 - это алгоритм Брензехема
        // И если печатать в консоль, то неудобно делать юнит тесты.
        // в этом весь смысл умение использовать моки
        // 40 тестировать не надо

        // 40.Write a routine to draw a circle(x** 2 + y** 2 = r** 2) without making use of any floating point
        // computations at all.
        // Time: O(4(R + 1) * Sqrt(R))
        // Space: O(4(R + 1))
        public static Point[] CalcCirclePoints(int centerX, int centerY, int radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Radius must be positive.", nameof(radius));
            }

            var result = new Point[(radius + 1) * 4];

            var r2 = radius * radius;
            for (var x = 0; x <= radius; x++)
            {
                var y = IntSqrt(r2 - x * x);
                // Quadrant1
                result[x] = new Point(centerX + x, centerY + y);
                // Quadrant2
                result[x + radius + 1] = new Point(centerX - x, centerY + y);
                // Quadrant3
                result[x + 2 * (radius + 1)] = new Point(centerX - x, centerY - y);
                // Quadrant4
                result[x + 3 * (radius + 1)] = new Point(centerX + x, centerY - y);
            }

            return result;
        }

        /// <summary>
        /// Calculates the closest integer square root. Time: O(Sqrt(value))
        /// </summary>
        /// <param name="value">The value in power of 2.</param>
        /// <returns>Integer square root.</returns>
        /// <exception cref="System.ArgumentException">It's not possible to calculate square root from a negative value. - value</exception>
        public static int IntSqrt(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("It's not possible to calculate square root from a negative value.",
                    nameof(value));
            }

            if (value < 2) return value;

            int bestDist = int.MaxValue;
            int bestResult = 0;
            for (var i = 1; i < value; i++)
            {
                var dist = Math.Abs(value - i * i);
                if (bestDist >= dist)
                {
                    bestDist = dist;
                    bestResult = i;
                }
                else
                {
                    break;
                }
            }

            return bestResult;
        }
    }
}