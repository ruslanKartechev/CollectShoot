using System;
using System.Collections;
using UnityEngine;

namespace GameCore.Utils.MonoUtils
{
    public interface ICoroutineService
    {
        Coroutine StartCor(IEnumerator enumerator);
        void StopCor(Coroutine coroutine);
        Coroutine DelayedAction(float time, Action action);
        Coroutine NextFrame(Action action);
        
    }
}