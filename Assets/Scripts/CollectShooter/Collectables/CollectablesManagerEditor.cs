#if UNITY_EDITOR
using GameCore.Editors;
using UnityEditor;
using UnityEngine;

namespace CollectShooter.Collectables
{
    [CustomEditor(typeof(CollectablesManager))]
    public class CollectablesManagerEditor : Editor
    {
        private CollectablesManager me;
        public void OnEnable()
        {
            me = target as CollectablesManager;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorUtils.LabelCenter("Spawning on grid");
            EditorUtils.Button("+", "Spawn entire grid", Color.green, me.Generate, me);
            EditorUtils.Button("-N", "Clear Nulls", Color.yellow, me.RemoveNulls, me);
            EditorUtils.Button("-A", "Clear Grid", Color.red, me.Clear, me);
            EditorUtils.Button("R", "RandomizeTeams", Color.cyan, me.RandomizeTeams, me);
            
            
        }
    }
}
#endif