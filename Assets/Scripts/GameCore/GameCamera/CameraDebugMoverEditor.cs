#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace GameCore.GameCamera
{
    [CustomEditor(typeof(CameraDebugMover))]
    public class CameraDebugMoverEditor : Editor
    {
        private CameraDebugMover me;

        private void OnEnable()
        {
            me = target as CameraDebugMover;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Set"))
            {
                me.Set();   
            }
        }
    }
}
#endif