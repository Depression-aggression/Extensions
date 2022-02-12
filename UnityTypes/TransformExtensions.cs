using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Depra.Extensions.UnityTypes
{
    /// <summary>
    /// <see cref="Transform"/> extensions.
    /// </summary>
    public static class TransformExtensions
    {
        public static Vector3 DirectionTo(this Transform source, Transform target)
        {
            return source.DirectionTo(target.position);
        }
        
        public static Vector3 DirectionTo(this Transform source, Vector3 target)
        {
            return (target - source.position).normalized;
        }
        
        public static void SetZLocal(this Transform transform, float zValue)
        {
            var lp = transform.localPosition;
            lp.z = zValue;
            transform.localPosition = lp;
        }

        public static void SetYLocal(this Transform transform, float yValue)
        {
            var lp = transform.localPosition;
            lp.y = yValue;
            transform.localPosition = lp;
        }

        public static void SetXLocal(this Transform transform, float xValue)
        {
            var lp = transform.localPosition;
            lp.x = xValue;
            transform.localPosition = lp;
        }

        public static void SetXWorld(this Transform transform, float xValue)
        {
            var lp = transform.position;
            lp.x = xValue;
            transform.position = lp;
        }

        public static void SetYWorld(this Transform transform, float yValue)
        {
            var lp = transform.position;
            lp.y = yValue;
            transform.position = lp;
        }

        public static void SetXZLocal(this Transform transform, float x, float z)
        {
            var lp = transform.localPosition;
            lp.x = x;
            lp.z = z;
            transform.localPosition = lp;
        }

        public static void SetXZLocal(this Transform transform, Transform newLp)
        {
            var lp = transform.localPosition;
            lp.x = newLp.localPosition.x;
            lp.z = newLp.localPosition.z;
            transform.localPosition = lp;
        }

        public static void SetXZWorld(this Transform transform, Transform newLp)
        {
            var lp = transform.position;
            lp.x = newLp.position.x;
            lp.z = newLp.position.z;
            transform.position = lp;
        }
        
        #region Syntax

        public static Vector3 backward(this Transform transform)
        {
            return -transform.forward;
        }

        public static Vector3 down(this Transform transform)
        {
            return -transform.up;
        }

        public static Vector3 left(this Transform transform)
        {
            return -transform.right;
        }
        
        #endregion
    
        [CanBeNull]
        public static T FindNearest<T>(this IEnumerable<T> array, List<T> skip, Vector3 point) where T : Component
        {
            float distance = float.PositiveInfinity;
            T result = null;

            foreach (var component in array)
            {
                if(skip.Contains(component))
                    continue;
            
                var currentTransform = component.transform;
                var currentDistance = Vector3.Distance(currentTransform.position, point);

                if (currentDistance < distance)
                {
                    result = component;
                    distance = currentDistance;
                }
            }

            return result;
        }

        [CanBeNull]
        public static T FindNearest<T>(this IEnumerable<T> array, Vector3 point) where T : Component
        {
            float distance = float.PositiveInfinity;
            T result = null;

            foreach (var component in array)
            {
                var currentTransform = component.transform;
                var currentDistance = Vector3.Distance(currentTransform.position, point);

                if (currentDistance < distance)
                {
                    result = component;
                    distance = currentDistance;
                }
            }

            return result;
        }
    
        [CanBeNull]
        public static T FindNearest<T>(this IEnumerable<T> array, Predicate<T> isIgnore, Vector3 point) where T : Component
        {
            float distance = float.PositiveInfinity;
            T result = null;

            foreach (var component in array)
            {
                if(isIgnore.Invoke(component))
                    continue;

                var currentTransform = component.transform;
                var currentDistance = Vector3.Distance(currentTransform.position, point);

                if (currentDistance < distance)
                {
                    result = component;
                    distance = currentDistance;
                }
            }

            return result;
        }
    
        [CanBeNull]
        public static T FindNearest<T>(this IEnumerable<T> array, Predicate<T> isIgnore, float maxDistance, Vector3 point) where T : Component
        {
            float distance = float.PositiveInfinity;
            T result = null;

            foreach (var component in array)
            {
                if(isIgnore.Invoke(component))
                    continue;

                var currentTransform = component.transform;
                var currentDistance = Vector3.Distance(currentTransform.position, point);
            
                if(currentDistance > maxDistance)
                    continue;

                if (currentDistance < distance)
                {
                    result = component;
                    distance = currentDistance;
                }
            }

            return result;
        }
    
        [CanBeNull]
        public static T FindNearest<T>(this IEnumerable<T> array, float maxDistance, Vector3 point) where T : Component
        {
            float distance = float.PositiveInfinity;
            T result = null;

            foreach (var component in array)
            {
                var currentTransform = component.transform;
                var currentDistance = Vector3.Distance(currentTransform.position, point);
            
                if(currentDistance > maxDistance)
                    continue;

                if (currentDistance < distance)
                {
                    result = component;
                    distance = currentDistance;
                }
            }

            return result;
        }
    }
}
