using UnityEngine;

namespace GameCore.GameCamera
{
    public class SimpleCameraFollowTarget : MonoBehaviour, ICameraFollowTarget
    {
        [SerializeField] private Transform _follow;
        [SerializeField] private Transform _lookAt;
        [SerializeField] private Vector3 _offset;
        
        public Transform Follow => _follow;
        public Transform LookAt => _lookAt;
        public Vector3 PositionOffset => _offset;



    }
}