using System;
using System.Diagnostics;

namespace Task54
{
    public static class CustomRandom
    {
        public static int Next(int min, int max)
        {
            if (max < min)
            {
                throw new Exception("Max should be more than min.");
            }

            var sysTicks = Environment.TickCount;
            var processTicks = Process.GetCurrentProcess().StartTime.Ticks;
            var nowTicks = DateTime.Now.Ticks;
            var guid = Guid.NewGuid();
            var mix = sysTicks.GetHashCode() ^ processTicks.GetHashCode() ^ nowTicks.GetHashCode() ^ guid.GetHashCode();
            return min + Math.Abs(mix) % Math.Abs(max - min);
        }
    }
}