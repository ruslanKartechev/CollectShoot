using UnityEngine;

namespace GameCore.GameCamera
{
    public interface ICameraFollowTarget
    {
        public Transform Follow { get; }
        public Transform LookAt { get; }
        public Vector3 PositionOffset { get; }
    }
}