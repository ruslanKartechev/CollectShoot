using UnityEngine;

namespace GameCore.GameCamera
{
    public struct CameraFollowArgs
    {
        public CameraFollowArgs(Transform lookAt, Transform follow, CameraFollowSettings settings)
        {
            this.lookAt = lookAt;
            this.follow = follow;
            this.settings = settings;
        }

        public Transform lookAt; 
        public Transform follow;
        public CameraFollowSettings settings;
    }
}