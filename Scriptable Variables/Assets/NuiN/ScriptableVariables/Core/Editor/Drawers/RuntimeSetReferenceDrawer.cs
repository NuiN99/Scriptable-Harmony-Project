using NuiN.ScriptableVariables.Core.Helpers;
using NuiN.ScriptableVariables.Core.RuntimeSet.References;
using UnityEditor;
using UnityEngine;

namespace NuiN.ScriptableVariables.Core.Editor
{
#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(RuntimeSetReader<>))]
    internal class RuntimeSetReaderDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) 
            => SOReferenceGUIHelper.VarRefGUI(SOType.RuntimeSet, Access.Getter, "runtimeSet", position, property, label, fieldInfo);

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) 
            => SOReferenceGUIHelper.GetPropertyHeight(property, label);
    }

    [CustomPropertyDrawer(typeof(RuntimeSetWriter<>))]
    internal class RuntimeSetWriterDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
            => SOReferenceGUIHelper.VarRefGUI(SOType.RuntimeSet, Access.Setter, "runtimeSet", position, property, label, fieldInfo);
        
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) 
            => SOReferenceGUIHelper.GetPropertyHeight(property, label);
    }
#endif
}


