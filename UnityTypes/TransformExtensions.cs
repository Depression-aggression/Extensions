using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public static class TransformExtensions
{
    public static void SetZLocal(this Transform transform, float zValue)
    {
        var lp = transform.localPosition;
        lp.z = zValue;
        transform.localPosition = lp;
    }

    public static void SetYLocal(this Transform transform, float YValue)
    {
        var lp = transform.localPosition;
        lp.y = YValue;
        transform.localPosition = lp;
    }

    public static void SetXLocal(this Transform transform, float XValue)
    {
        var lp = transform.localPosition;
        lp.x = XValue;
        transform.localPosition = lp;
    }

    public static void SetXWorld(this Transform transform, float XValue)
    {
        var lp = transform.position;
        lp.x = XValue;
        transform.position = lp;
    }

    public static void SetYWorld(this Transform transform, float YValue)
    {
        var lp = transform.position;
        lp.y = YValue;
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
    
     [CanBeNull]
    public static T FindClosed<T>(this IEnumerable<T> array, List<T> skip, Vector3 point) where T : Component
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
    public static T FindClosed<T>(this IEnumerable<T> array, Vector3 point) where T : Component
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
    
    public static T FindClosed<T>(this IEnumerable<T> array, Predicate<T> isIgnore, Vector3 point) where T : Component
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
    
    public static T FindClosed<T>(this IEnumerable<T> array, Predicate<T> isIgnore, float maxDistance, Vector3 point) where T : Component
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
    
    public static T FindClosed<T>(this IEnumerable<T> array, float maxDistance, Vector3 point) where T : Component
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

    public static Vector3 DirectionTo(this Transform transform, Vector3 target)
    {
        return (target - transform.position).normalized;
    }
}
