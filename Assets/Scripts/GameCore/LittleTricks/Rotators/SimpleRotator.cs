using System;
using System.Collections;
using UnityEngine;

namespace GameCore.LittleTricks.Rotators
{
    public class SimpleRotator : MonoBehaviour
    {
        public Transform rotatable;
        public float rotationSpeed;
        private Coroutine _rotating;
        
        public void RotateToInPlane(Vector3 position, Action onEnd)
        {
            Stop();
            position.y = rotatable.position.y;
            var endRotation = Quaternion.LookRotation(position - rotatable.position);
            var time = ((endRotation.eulerAngles - rotatable.rotation.eulerAngles).magnitude / rotationSpeed);
            _rotating = StartCoroutine(Rotating(rotatable.rotation, endRotation, time, onEnd));
        }

        public void Stop()
        {
            if(_rotating != null)
                StopCoroutine(_rotating);
        }

        private IEnumerator Rotating(Quaternion start, Quaternion end, float time, Action onEnd)
        {
            var elapsed = 0f;
            while (elapsed < time)
            {
                var rot = Quaternion.Lerp(start, end, elapsed / time);
                rotatable.rotation = rot;
                elapsed += Time.deltaTime;
                yield return null;
            }
            rotatable.rotation = end;
            onEnd.Invoke();
        }
    }
}