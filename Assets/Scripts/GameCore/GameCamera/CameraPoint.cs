using System;
using System.Collections;
using GameCore.Data;
using UnityEngine;

namespace GameCore.GameCamera
{
    public class CameraPoint : MonoBehaviour
    {
        public Transform Point;
        public Transform LookTarget;
        public CameraFollowSettings FollowSettings;
        public bool AutoSetInEditor = true;
        private ICameraPointMover _cameraMover;

        public void SetToThisPoint()
        {
            #if UNITY_EDITOR
            if (Application.isPlaying == false)
            {
                var cam = FindObjectOfType<Camera>().transform;
                cam.position = Point.position;
                cam.rotation = Quaternion.LookRotation(LookTarget.position - Point.position);
                return;
            }
            #endif
            _cameraMover = GlobalContainer.CameraPointMover;
            _cameraMover.StopMoving();
            _cameraMover.SetPosition(Point.position);
            _cameraMover.SetLookAt( LookTarget.position);
        }
        
        public void MoveToThisPoint(float time, Action onEnd)
        {
#if UNITY_EDITOR
            if (Application.isPlaying == false)
            {
                var cam = FindObjectOfType<Camera>().transform;
                cam.position = Point.position;
                cam.rotation = Quaternion.LookRotation(LookTarget.position - Point.position);
                return;
            }
#endif
            _cameraMover = GlobalContainer.CameraPointMover;
            _cameraMover.ChangePosition(Point.position, time, onEnd);
            _cameraMover.ChangeRotation(transform.rotation, time, null);
        }
        
        public void LockOnThisPoint()
        {
            // Debug.Log("locked");
            GlobalContainer.CameraPointMover.Lock(Point);
        }

        public void Unlock()
        {
            // Debug.Log("unlocked");
            GlobalContainer.CameraPointMover.StopMoving();
        }


        public void FollowThisPoint()
        {
            GlobalContainer.CameraPointMover.Follow(new CameraFollowArgs(LookTarget, Point, FollowSettings));
        }
    }
}