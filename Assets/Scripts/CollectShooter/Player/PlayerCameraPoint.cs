using GameCore.GameCamera;
using UnityEngine;

namespace LabShoot.Player
{
    public class PlayerCameraPoint : MonoBehaviour
    {
        public CameraPoint camPoint;

        public void Init()
        {
            camPoint.FollowThisPoint();   
        }

        public void Disable()
        {
            camPoint.Unlock();
        }
    }
}