#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace GameCore.Stats.Money
{
    [CustomEditor(typeof(MoneyCheat))]
    public class MoneyCheatEditor : Editor
    {
        private MoneyCheat me;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var me = target as MoneyCheat;
            if (GUILayout.Button("Add"))
            {
                me.Add();
            }

            if (GUILayout.Button("Set 0"))
            {
                me.SetZero();
            }
        }
    }
}
#endif