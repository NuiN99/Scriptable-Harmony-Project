using NuiN.ScriptableVariables.Core.Editor.Helpers;
using NuiN.ScriptableVariables.Internal.Helpers;
using NuiN.ScriptableVariables.RuntimeSingle.References;
using UnityEditor;
using UnityEngine;

namespace NuiN.ScriptableVariables.Internal.Editor
{
#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(GetRuntimeSingle<>))]
    internal class RuntimeSingleReaderDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) 
            => SOReferenceGUIHelper.VarRefGUI(SOType.RuntimeSingle, Access.Getter, "runtimeSingle", position, property, label, fieldInfo);

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) 
            => SOReferenceGUIHelper.GetPropertyHeight(property, label);
    }

    [CustomPropertyDrawer(typeof(SetRuntimeSingle<>))]
    internal class RuntimeSingleWriterDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
            => SOReferenceGUIHelper.VarRefGUI(SOType.RuntimeSingle, Access.Setter, "runtimeSingle", position, property, label, fieldInfo);
        
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) 
            => SOReferenceGUIHelper.GetPropertyHeight(property, label);
    }
#endif
}

