using UnityEditor;
using UnityEngine;

namespace GameCore.Levels
{
    #if UNITY_EDITOR
    [CustomEditor(typeof(SceneLevelManager))]
    public class SceneLevelManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            SceneLevelManager me = target as SceneLevelManager;
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("<<", GUILayout.Width(50)))
            {
                me.editorSwitcher.Prev(me.Levels);                      
                EditorUtility.SetDirty(me);
            }
            else if(GUILayout.Button(">>", GUILayout.Width(50)))
            {
                me.editorSwitcher.Next(me.Levels);
                EditorUtility.SetDirty(me);
            }
            else if (GUILayout.Button("Clear", GUILayout.Width(100)))
            {
                me.editorSwitcher.Unload();
                EditorUtility.SetDirty(me);
            }
            else if (GUILayout.Button("Reset", GUILayout.Width(100)))
            {
                me.editorSwitcher.Reset();
                EditorUtility.SetDirty(me);

            }
            GUILayout.EndHorizontal();
        }
    }
    #endif
}