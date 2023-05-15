using UnityEditor;
using UnityEngine;

namespace GameCore.GameCamera
{
    public class EditorOnlyCameraPoint : MonoBehaviour
    {
        public bool DoSetPosition;
        public bool DoSetInPlayMode;
        public Camera camera;
        
        public void Apply()
        {
            // Debug.Log("on selected");
            if (!DoSetPosition)
                return;
            if (Application.isPlaying && !DoSetInPlayMode)
                return;
            Set();
        }

        private void Set()
        {
            Transform tm = null;
            if (camera == null)
            {
                camera = FindObjectOfType<Camera>();
                if (camera == null)
                    return;
            }
            tm = camera.transform.parent;
            tm.position = transform.position;
            tm.rotation = transform.rotation;
        }
    }

    #if UNITY_EDITOR
    [CustomEditor(typeof(EditorOnlyCameraPoint))]
    public class EditorOnlyCameraPointEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var me = target as EditorOnlyCameraPoint;
            me.Apply();
        }
    }
    #endif
}