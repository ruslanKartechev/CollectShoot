using System;
using UnityEngine;

namespace GameCore.GameCamera
{
    public interface ICameraPointMover
    {
        public void Lock(Transform moveTarget);

        public void ChangePosition(Vector3 endPosition, float time, Action onEnd);
        public void ChangeRotation(Quaternion endRotation, float time, Action onEnd);

        public void StopMoving();
        
        public void SetPosition(Vector3 position);
        public void SetLookAt(Vector3 position);

        public void Follow(CameraFollowArgs followArgs);
    }
}