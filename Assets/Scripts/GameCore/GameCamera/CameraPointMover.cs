using System;
using System.Collections;
using UnityEngine;

namespace GameCore.GameCamera
{
    public class CameraPointMover : MonoBehaviour, ICameraPointMover
    {
    
        public Transform DefaultParent;
        [SerializeField] private AnimationCurve _rotCurve;
        [SerializeField] private AnimationCurve _moveCurve;
        private Coroutine _posChange;
        private Coroutine _rotChange;

        public void SetPosition(Vector3 position )
        {
            transform.position = position;
        }

        public void SetLookAt(Vector3 position)
        {
            transform.rotation = Quaternion.LookRotation(position - transform.position);
        }
        
        public void StopMoving()
        {
            transform.parent = DefaultParent;
            StopAll();
        }
        
        public void Lock(Transform moveTarget)
        {
            StopAll();
            transform.parent = moveTarget;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }


        public void ChangePosition(Vector3 endPosition, float time, Action onEnd)
        {
            StopMove();
            _posChange = StartCoroutine(ChangingPosition(endPosition, time, onEnd));
        }

        public void ChangeRotation(Quaternion endRotation, float time, Action onEnd)
        {
            StopRotate();
            _rotChange = StartCoroutine(ChangingRotation(endRotation, time, onEnd));
        }
        
        public void Follow(CameraFollowArgs followArgs)
        {
            StopAll();
            _posChange = StartCoroutine(Following(followArgs));
        }
        

        private void StopMove()
        {
            if(_posChange != null)
                StopCoroutine(_posChange);
        }

        private void StopRotate()
        {
            if(_rotChange != null)
                StopCoroutine(_rotChange);
        }

        private void StopAll()
        {
            StopMove();
            StopRotate();
        }


        private IEnumerator ChangingPosition(Vector3 endPos, float time, Action onEnd)
        {
            var start = transform.position;
            if (time == 0)
            {
                transform.position = endPos;
                yield break;
            }
            var elapsed = 0f;
            while (elapsed <= time)
            {
                var t = elapsed / time;
                transform.position = Vector3.Lerp(start, endPos, t);
                elapsed += Time.deltaTime * _moveCurve.Evaluate(t);
                yield return null;
            }
            transform.position = endPos;
            onEnd?.Invoke();
        }
        
        private IEnumerator ChangingRotation(Quaternion endRot, float time, Action onEnd)
        {
            var start = transform.rotation;
            if (time == 0)
            {
                transform.rotation = endRot;
                yield break;
            }
            var elapsed = 0f;
            while (elapsed <= time)
            {
                var t = elapsed / time;
                transform.rotation = Quaternion.Lerp(start, endRot, t);
                elapsed += Time.deltaTime * _moveCurve.Evaluate(t);
                yield return null;
            }
            transform.rotation = endRot;
            onEnd?.Invoke();
        }

        
        private IEnumerator Following(CameraFollowArgs args)
        {
            while (true)
            {
                transform.position = args.follow.position + args.settings.offset;
                transform.rotation = Quaternion.LookRotation(args.lookAt.position - transform.position);
                yield return null;
            }   
        }
        
    }
}