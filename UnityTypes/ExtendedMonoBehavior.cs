using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace Depra.Extensions.UnityTypes
{
    public class ExtendedMonoBehavior : MonoBehaviour
    {
        #region Coroutines

        /// <summary>
        /// Invoke at Coroutine.
        /// </summary>
        /// <param name="time">in seconds</param>
        /// <param name="endAction"> Action </param>
        public void InvokeAtTime(float time, Action endAction)
        {
            StartCoroutine(WaitPlugin(time, endAction));
        }

        /// <summary>
        /// Wait condition.
        /// </summary>
        /// <param name="cond">Condition. If true then endAction invoke</param>
        /// <param name="endAction"> end action</param>
        public void InvokeAtCondition([NotNull] Func<bool> cond, Action endAction)
        {
            StartCoroutine(WaitConditionPlugin(cond, endAction));
        }

        private IEnumerator WaitPlugin(float time, Action endAction)
        {
            yield return new WaitForSeconds(time);
            endAction?.Invoke();
        }

        private IEnumerator WaitConditionPlugin(Func<bool> cond, Action endAction)
        {
            while (cond.Invoke() == false)
            {
                yield return null;
            }

            endAction?.Invoke();
            yield return null;
        }
        
        #endregion

        #region Syntax
        
        public void GetOrAddComponent<T>() where T: Component
        {
            gameObject.GetOrAddComponent<T>();
        }
        
        #endregion
    }
}
