#if UNITY_EDITOR
using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace NuiN.ScriptableHarmony.Editor.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class SOMethodButton : PropertyAttribute
    {
        public readonly string label;
        public readonly bool onlyShowInPlayMode;
        public readonly object[] parameters;
        public SOMethodButton(string label, bool onlyShowInPlayMode = false, object[] parameters = null)
        {
            this.label = label;
            this.parameters = parameters;
            this.onlyShowInPlayMode = onlyShowInPlayMode;
        }
    }

    [CustomEditor(typeof(ScriptableObject), true)]
    public class EditorButtonDrawer : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            ScriptableObject script = (ScriptableObject)target;
            MethodInfo[] methods = script.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(method => method.GetCustomAttributes(typeof(SOMethodButton), true).Length > 0)
                .ToArray();

            foreach (var method in methods)
            {
                SOMethodButton attribute = (SOMethodButton)method.GetCustomAttributes(typeof(SOMethodButton), true)[0];
                string buttonLabel = attribute == null ? method.Name : attribute.label;

                if (attribute == null || (!Application.isPlaying && !attribute.onlyShowInPlayMode)) continue;
                if (GUILayout.Button(buttonLabel)) method.Invoke(script, attribute?.parameters);
            }
            
            base.OnInspectorGUI();

        }
    }
#endif
}
