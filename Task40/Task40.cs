using System;
using System.Drawing;

namespace Task40
{
    public static class Task40
    {
        // 40.Write a routine to draw a circle(x** 2 + y** 2 = r** 2) without making use of any floating point
        // computations at all.
        // Time: O(4(R + 1) * Sqrt(R))
        // Space: O(4(R + 1))
        public static void DrawCircle(Bitmap bmp, Color color, int centerX, int centerY, int radius)
        {
            if (bmp == null)
            {
                throw new ArgumentNullException(nameof(bmp));
            }

            if (bmp.Width < centerX + radius || bmp.Height < centerY + radius)
            {
                throw new ArgumentException("Can't fit circle to the bitmap.");
            }

            if (radius <= 0)
            {
                throw new ArgumentException("Radius must be positive.", nameof(radius));
            }

            var r2 = radius * radius;
            for (var x = 0; x < radius; x++)
            {
                var y = IntSqrt(r2 - x * x);
                var yp1 = IntSqrt(r2 - (x + 1) * (x + 1));
                
                // Quadrant1
                var x1 = centerX + x;
                var y1 = centerY + y;
                var x2 = centerX + x + 1;
                var y2 = centerY + yp1;
                DrawLine(bmp, color, x1, y1, x2, y2);

                // Quadrant2
                x1 = centerX - x;
                y1 = centerY + y;
                x2 = centerX - x - 1;
                y2 = centerY + yp1;
                DrawLine(bmp, color, x1, y1, x2, y2);

                // Quadrant3
                x1 = centerX - x;
                y1 = centerY - y;
                x2 = centerX - x - 1;
                y2 = centerY - yp1;
                DrawLine(bmp, color, x1, y1, x2, y2);

                // Quadrant4
                x1 = centerX + x;
                y1 = centerY - y;
                x2 = centerX + x + 1;
                y2 = centerY - yp1;
                DrawLine(bmp, color, x1, y1, x2, y2);
            }

            bmp.SetPixel(centerX + radius - 1, centerY, color);
            bmp.SetPixel(centerX - radius + 1, centerY, color);
        }

        /// <summary>
        /// Draws line between 2 points. Time: O(L) where L - line length. Space: O(1).
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="color"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        public static void DrawLine(Bitmap bmp, Color color, int x1, int y1, int x2, int y2)
        {
            var difX = Math.Abs(x2 - x1);
            var difY = Math.Abs(y2 - y1);
            if (difY == 0 && difX == 0)
            {
                bmp.SetPixel(x1, y1, color);
                return;
            }

            int x = 0, y = 0;
            int signX = Math.Sign(x2 - x1);
            int signY = Math.Sign(y2 - y1);

            if (difX > difY)
            {
                int remY = difY % difX;
                int accY = 0;
                while (x1 + x != x2)
                {
                    bmp.SetPixel(x1 + x, y1 + y, color);
                    x += signX;
                    accY += remY;
                    if (accY >= difX)
                    {
                        y += signY;
                        accY -= difX;
                    }
                }
            }
            else if (difX < difY)
            {
                int remX = difX % difY;
                int accX = 0;

                while (y1 + y != y2)
                {
                    bmp.SetPixel(x1 + x, y1 + y, color);
                    y += signY;
                    accX += remX;
                    if (accX >= difY)
                    {
                        x += signX;
                        accX -= difY;
                    }
                }
            }
            else
            {
                for (int i = 0; i < difX; i++)
                {
                    bmp.SetPixel(x1 + i*signX, y1 + i*signY, color);
                }
            }
        }

        /// <summary>
        /// Calculates the closest integer square root. Time: O(Sqrt(value)). Space: O(1).
        /// </summary>
        /// <param name="value">The value in power of 2.</param>
        /// <returns>Integer square root.</returns>
        /// <exception cref="System.ArgumentException">It's not possible to calculate square root from a negative value. - value</exception>
        private static int IntSqrt(int value)
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