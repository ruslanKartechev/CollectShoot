using UnityEditor;
using UnityEngine;

namespace GameCore.Editors
{
    #if UNITY_EDITOR
    public class EmptyTemplate : MonoBehaviour
    {
        
    }
    
    
    
    [CustomEditor(typeof(EmptyTemplate))]
    public class StatueMaterialSwitcherEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var me = target as EmptyTemplate;
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Action 1", GUILayout.Width(125)))
            {
                //
                EditorUtility.SetDirty(me);
            }

            if (GUILayout.Button("Action 2", GUILayout.Width(125)))
            {
                //
                EditorUtility.SetDirty(me);
            }
            GUILayout.EndHorizontal();

        }
    }
    #endif
}