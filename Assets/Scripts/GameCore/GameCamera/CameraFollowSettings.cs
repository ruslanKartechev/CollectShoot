using UnityEngine;

namespace GameCore.GameCamera
{
    [CreateAssetMenu(fileName = nameof(CameraFollowSettings), menuName = "SO/" + nameof(CameraFollowSettings))]
    public class CameraFollowSettings : ScriptableObject
    {
        public Vector3 offset;
    }
}