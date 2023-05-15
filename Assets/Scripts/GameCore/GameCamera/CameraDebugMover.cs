using UnityEngine;

namespace GameCore.GameCamera
{
    public class CameraDebugMover : MonoBehaviour
    {
        public Vector3 offset;
        public Transform followTarget;
        public Transform lookTarget;
        public CameraFollowSettings setToSettings;
        public bool isActive;

        private void OnValidate()
        {
            if (!isActive )
                return;
            if (followTarget == null || lookTarget == null)
                return;
            Set();
        }

        public void Set()
        {
            transform.position = followTarget.position + offset;
            transform.rotation = Quaternion.LookRotation(lookTarget.position - transform.position);
            if (setToSettings != null)
            {
                setToSettings.offset = offset;
            }
        }
    }
}