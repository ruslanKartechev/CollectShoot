#if UNITY_EDITOR

using GameCore.Editors;
using UnityEditor;
using UnityEngine;

namespace GameCore.Servises.Ragdoll
{
    [CustomEditor(typeof(RagdollManager))]
    public class RagdollManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var me = target as RagdollManager;

            EditorUtils.LabelCenter("Ragdoll");
            GUILayout.BeginHorizontal();
            EditorUtils.ButtonNoText("G", Color.cyan, me.GetAllParts, me);
            EditorUtils.ButtonNoText("On", Color.green, me.Activate, me);
            EditorUtils.ButtonNoText("Off", Color.red, me.Deactivate, me);
            GUILayout.EndHorizontal();
            GUILayout.Space((10));
            EditorUtils.LabelCenter("Interpolate");

            GUILayout.BeginHorizontal();
            EditorUtils.ButtonNoText("Y", Color.green, me.SetAllInterpolate, me);
            EditorUtils.ButtonNoText("N", Color.red, me.SetAllNoInterpolate, me);
            GUILayout.EndHorizontal();
            
            GUILayout.Space((10));

            EditorUtils.LabelCenter("Projection");
            GUILayout.BeginHorizontal();
            EditorUtils.ButtonNoText("Y", Color.green, me.SetProjection, me);
            EditorUtils.ButtonNoText("N", Color.red, me.SetNoProjection, me);
            GUILayout.EndHorizontal();
            
            EditorUtils.LabelCenter("Preprocessing");
            GUILayout.BeginHorizontal();
            EditorUtils.ButtonNoText("On", Color.green, () => { me.SetAllPreprocess(true);}, me);
            EditorUtils.ButtonNoText("Off", Color.red,  () => { me.SetAllPreprocess(false);}, me);            
            GUILayout.EndHorizontal();
            GUILayout.Space((10));
            base.OnInspectorGUI();
            
       
        }
    }
}
#endif