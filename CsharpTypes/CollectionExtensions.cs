using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Depra.Extensions
{
    public static class CollectionExtensions
    {
        #region Random
        
        /// <summary>
        /// Return random element.
        /// </summary>
        /// <param name="elements">list</param>
        /// <typeparam name="T">type</typeparam>
        /// <returns>random element</returns>
        public static T RandomElement<T>(this IEnumerable<T> elements)
        {
            return elements.Any() == false 
                ? default(T)
                : elements.ElementAt(Random.Range(0, elements.Count()));
        }

        #endregion

        #region Searching

        /// <summary>
        /// Search nearest point.
        /// </summary>
        /// <param name="array">Point as components</param>
        /// <param name="point">Position</param>
        /// <typeparam name="T">Point type</typeparam>
        /// <returns>Nearest/closest point</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Transform FindClosestPoint<T>(this IEnumerable<T> array, Vector3 point) where T : Component
        {
            var distance = float.PositiveInfinity;
            Transform result = null;

            foreach (var component in array)
            {
                var currentTransform = component.transform;
                var currentDistance = Vector3.Distance(currentTransform.position, point);

                if (currentDistance < distance)
                {
                    result = currentTransform;
                    distance = currentDistance;
                }
            }

            if (result == null)
            {
                throw new ArgumentNullException(nameof(array), "array argument empty");
            }

            return result;
        }

        #endregion
    }
}