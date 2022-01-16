using System;
using UnityEngine;

namespace Depra.Extensions
{
    public static class DFloat
    {
        public const float Zero = 0.0f;
    }
    
    public static class FloatExtensions
    {
        public static float GaussFalloff(float distance, float inRadius)
        {
            return Mathf.Clamp01(Mathf.Pow(360f, -Mathf.Pow(distance / inRadius, 2.5f) - 0.01f));
        }

        /// <summary>
        /// Is this float approximately other.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool Approximately(this float a, float other)
        {
            return Mathf.Approximately(a, other);
        }

        /// <summary>
        /// Is this float within range of other.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="other"></param>
        /// <param name="delta"></param>
        /// <returns></returns>
        public static bool Approximately(this float x, float other, float delta)
        {
            return Math.Abs(x - other) < delta;
        }

        //public unsafe static float FastInvSqrt(float x)
        //{
        //    float xhalf = 0.5f * x;
        //    int i = *(int*)&x;
        //    i = 0x5f375a86 - (i >> 1); //this constant is slightly more accurate than the common one
        //    x = *(float*)&i;
        //    x = x * (1.5f - xhalf * x * x);
        //    return x;
        //}

        //public unsafe static float FastSqrt(float x)
        //{
        //    float xhalf = 0.5f * x;
        //    int i = *(int*)&x;
        //    i = 0x1fbd1df5 + (i >> 1);  // da magicks
        //    x = *(float*)&i;
        //    x = x * (1.5f - (xhalf * x * x)); //newtons method to improve approximation
        //    return x;
        //}
    }

    public static class IntExtensions
    {
        public static string ConvertSeconds(int time)
        {
            var _minutes = time / 60;
            string minutes = "";
            int _seconds = time % 60;
            string seconds = "";

            if (_minutes > 0)
            {
                minutes = _minutes + " minute" + (_minutes > 1 ? "s " : " ");
            }

            if (_seconds > 0)
            {
                seconds = _seconds + " second" + (_seconds > 1 ? "s " : " ");
            }

            return (minutes + seconds).Substring(0, (minutes + seconds).Length - 1);
        }
    }
}