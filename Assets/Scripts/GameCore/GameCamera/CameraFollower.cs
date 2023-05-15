using System.Collections;
using UnityEngine;

namespace GameCore.GameCamera
{
    public class CameraFollower : MonoBehaviour
    {
        public Transform Movable;

        private ICameraFollowTarget _currentTarget;
        private Coroutine _moving;
        
        private bool _follow;
        public bool DoFollow
        {
            get => _follow;
            set
            {
                _follow = value;
                Stop();
                if (_follow)
                {
                    _moving = StartCoroutine(Following());
                }
            }
        }

        public void SetTarget(ICameraFollowTarget target)
        {
            _currentTarget = target;
        }

        private void Stop()
        {
            if(_moving != null)
                StopCoroutine(_moving);
        }

        private IEnumerator Following()
        {
            while (true)
            {
                Movable.position = _currentTarget.Follow.TransformPoint(_currentTarget.PositionOffset);
                Movable.rotation = Quaternion.LookRotation(_currentTarget.LookAt.position - Movable.position);
                yield return null;
            }    
        }
        
    }
}