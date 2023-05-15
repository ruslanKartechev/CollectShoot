#if UNITY_EDITOR

using System;
using UnityEditor;
using UnityEngine;

namespace GameCore.Editors
{
    public class EditorUtils
    {
        public const int btnSizeSmall = 35;
        public const int btnSizeNormal = 35;
        public const int btnSizeBig = 45;
        
        public const int HeaderFontSize = 15;
        public const int SmallLabelSize = 12;
        
        public static void LabelCenter(string name)
        {
            GetLabelStyle();
            var style = GetLabelStyle();
            style.alignment = TextAnchor.MiddleCenter;
            style.fontSize = HeaderFontSize;
            GUILayout.Label(name, style);
        }
        
        public static void LabelLeft(string name)
        {
            GetLabelStyle();
            var style = GetLabelStyle();
            style.alignment = TextAnchor.MiddleLeft;
            style.fontSize = SmallLabelSize;
            style.fixedHeight = btnSizeSmall;
            GUILayout.Label(name, style);
        }
        
        
        public static bool Button(string shotName, string bigName, Color color, Action onClick, UnityEngine.Object me, float leftOffset = 0)
        {
            if (shotName == null)
                shotName = " ";
            GUI.color = color;
            GUILayout.BeginHorizontal();
            GUILayout.Space(leftOffset);
            var style = GetBtnStyleSmall();
            var res = false;
            if (GUILayout.Button(shotName, style))
            {
                onClick.Invoke();   
                EditorUtility.SetDirty(me);
                res = true;
            }
            LabelLeft(bigName);
            GUILayout.EndHorizontal();
            GUI.color = Color.white;
            return res;
        }
        
        public static void ButtonNoText(string shotName, Color color, Action onClick, UnityEngine.Object me, float leftOffset = 0)
        {
            if (shotName == null)
                shotName = " ";
            GUI.color = color;
            // GUILayout.BeginHorizontal();
            var style = GetBtnStyleNormal();
            if (GUILayout.Button(shotName, style))
            {
                onClick.Invoke();   
                EditorUtility.SetDirty(me);
            }
            // GUILayout.EndHorizontal();
            GUI.color = Color.white;
        }
        

        public static GUIStyle GetLabelStyle()
        {
            var style = new GUIStyle(GUI.skin.GetStyle("Label"));
            style.fontStyle = FontStyle.Bold;
            return style;
        }

        public static GUIStyle GetBtnStyleSmall()
        {
            var style = new GUIStyle(GUI.skin.GetStyle("Button"));
            style.alignment = TextAnchor.MiddleCenter;
            style.fontStyle = FontStyle.BoldAndItalic;
            style.normal.textColor = Color.white;
            style.fixedWidth = style.fixedHeight = btnSizeSmall;
            return  style;
        }
        
        public static GUIStyle GetBtnStyleNormal()
        {
            var style = new GUIStyle(GUI.skin.GetStyle("Button"));
            style.alignment = TextAnchor.MiddleCenter;
            style.fontStyle = FontStyle.BoldAndItalic;
            style.normal.textColor = Color.white;
            style.fixedWidth = style.fixedHeight = btnSizeNormal;
            return  style;
        }
        
    }
}
#endif