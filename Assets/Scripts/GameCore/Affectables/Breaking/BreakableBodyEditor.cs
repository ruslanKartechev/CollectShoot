#if UNITY_EDITOR
using GameCore.Editors;
using UnityEditor;
using UnityEngine;

namespace GameCore.Affectables.Breaking
{
    [CustomEditor(typeof(BreakableBody))]
    public class BreakableBodyEditor : Editor
    {
        private BreakableBody me;
        private bool _setVisible = true;
        private bool _removeCollidersAndRbs = false;

        private void OnEnable()
        {
            me = target as BreakableBody;
        }

        public override void OnInspectorGUI()
        {
            Options();
            GUILayout.Space(10);
            GUILayout.BeginHorizontal();
            EditorUtils.Button($"G", "Get", Color.cyan, me.GetParts, me);
            EditorUtils.Button($"N", "Nulls", Color.cyan, me.ClearNulls, me);
            EditorUtils.Button($"R", "Clear", Color.red, () =>
            {
                me.ClearAll(_removeCollidersAndRbs);
            }, me);
            GUILayout.EndHorizontal();
            GUILayout.Space(10);
            
            GUILayout.BeginHorizontal();
            EditorUtils.Button($"A", "Active", Color.cyan, () =>
            {
                me.SetActive(true, _setVisible);
            }, me);
            EditorUtils.Button($"P", "Passive", Color.cyan, () =>
            {
                me.SetActive(false, _setVisible);
            }, me);
            GUILayout.EndHorizontal();
            GUILayout.Space(5);
            EditorUtils.Button($"B", "Break from center defaul force", Color.yellow, me.BreakFromCenterDefault, me);
            base.OnInspectorGUI();
        }

        private void Options()
        {
            var prevLabelWidth = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth = 250;
            _setVisible = EditorGUILayout.Toggle("Set visible when active", _setVisible);
            _removeCollidersAndRbs = EditorGUILayout.Toggle("Remove Rb and Coll when removing", _removeCollidersAndRbs);
            EditorGUIUtility.labelWidth = prevLabelWidth;
        }
    }
}

#endif