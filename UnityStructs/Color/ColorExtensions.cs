using UnityEngine;

namespace Depra.Extensions.UnityStructs
{
    /// <summary>
    /// <see cref="Color"/> extensions.
    /// </summary>
    public static class ColorExtensions
    {
        public static HSV ToHsv(this UnityEngine.Color color)
        {
            return HSV.FromColor(color);
        }

        public static HSL ToHsl(this UnityEngine.Color color)
        {
            return HSL.FromColor(color);
        }

        /// <summary>
        /// Returns a random color.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="minClamp"></param>
        /// <returns></returns>
        public static UnityEngine.Color MakeRandomColor(this UnityEngine.Color color, float minClamp = 0.5f)
        {
            var randCol = Random.onUnitSphere * 3;
            randCol.x = Mathf.Clamp(randCol.x, minClamp, 1f);
            randCol.y = Mathf.Clamp(randCol.y, minClamp, 1f);
            randCol.z = Mathf.Clamp(randCol.z, minClamp, 1f);

            return new UnityEngine.Color(randCol.x, randCol.y, randCol.z, 1f);
        }

        /// <summary>
        /// Direct speedup of <seealso cref="Color.Lerp"/>
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static UnityEngine.Color Lerp(UnityEngine.Color c1, UnityEngine.Color c2, float value)
        {
            if (value > 1.0f)
            {
                return c2;
            }

            if (value < 0.0f)
            {
                return c1;
            }

            return new UnityEngine.Color(c1.r + (c2.r - c1.r) * value,
                c1.g + (c2.g - c1.g) * value,
                c1.b + (c2.b - c1.b) * value,
                c1.a + (c2.a - c1.a) * value);
        }
    }
}
