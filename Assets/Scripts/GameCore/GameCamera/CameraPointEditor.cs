#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace GameCore.GameCamera
{
    [CustomEditor(typeof(CameraPoint))]
    public class CameraPointEditor : Editor
    {
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var me = target as CameraPoint;
            
            if (me.AutoSetInEditor && Application.isPlaying == false)
            {
                me.SetToThisPoint();
            }
            
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("SetThisPoint"))
            {
                me.SetToThisPoint();
            }
            if (GUILayout.Button("MoveToThisPoint, 1s"))
            {
                me.MoveToThisPoint(1f, null);
            }
            GUILayout.EndHorizontal();
        }
    }
}
#endif