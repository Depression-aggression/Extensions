using System.Diagnostics;

namespace Depra.Extensions
{
    /// <summary>
    /// <see cref="Stopwatch"/> extensions.
    /// </summary>
    public static class StopwatchExtension
    {
        public static long ElapsedSeconds(this Stopwatch sw)
        {
            return sw.ElapsedMilliseconds / 1000;
        }
    }
}