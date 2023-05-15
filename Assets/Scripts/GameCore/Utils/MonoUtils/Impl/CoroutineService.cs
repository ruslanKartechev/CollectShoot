using System;
using System.Collections;
using UnityEngine;

namespace GameCore.Utils.MonoUtils.Impl
{
    public class CoroutineService : MonoBehaviour, ICoroutineService
    {
        public Coroutine StartCor(IEnumerator enumerator)
        {
            return StartCoroutine(enumerator);
        }

        public void StopCor(Coroutine coroutine)
        {
            if(coroutine != null)
                StopCoroutine(coroutine);
        }

        public Coroutine DelayedAction(float time, Action action)
        {
            return StartCoroutine(Delayed(time, action));
        }

        public Coroutine NextFrame(Action action)
        {
            return StartCoroutine(DelayFrame(action));
        }

        private IEnumerator DelayFrame(Action action)
        {
            yield return null;
            action.Invoke();
        }        

        private IEnumerator Delayed(float time, Action action)
        {
            yield return new WaitForSeconds(time);
            action.Invoke();
        }
    }
    
}