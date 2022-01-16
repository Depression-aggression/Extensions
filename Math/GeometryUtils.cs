using UnityEngine;

namespace Depra.Extensions
{
    /// <summary>
    /// геометрия
    /// </summary>
    public static class GeometryUtils
    {
        /// <summary>
        /// наход точку на прямой по заданной дистанции
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="newDistance"></param>
        /// <returns></returns>
        public static Vector3 FindPointInLineAtDistance(Vector3 a, Vector3 b, float newDistance)
        {
            return a + (b - a) * (newDistance / Vector3.Distance(a, b));
        }

        /// <summary>
        /// наход точку на прямой по заданной дистанции
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="newDistance"></param>
        /// <returns></returns>
        public static Vector2 FindPointInLineAtDistance(Vector2 a, Vector2 b, float newDistance)
        {
            return a + (b - a) * (newDistance / Vector2.Distance(a, b));
        }

        /// <summary>
        /// находит точку на прямой по процентам от дистанции
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="percentValue">100% == 1f</param>
        /// <returns></returns>
        public static Vector3 FindPointInLineAtPercent(Vector3 a, Vector3 b, float percentValue)
        {
            return a + (b - a) * percentValue;
        }

        /// <summary>
        /// находит точку на прямой по процентам от дистанции
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="percentValue">100% == 1f</param>
        /// <returns></returns>
        public static Vector2 FindPointInLineAtPercent(Vector2 a, Vector2 b, float percentValue)
        {
            return a + (b - a) * percentValue;
        }
    }
}
