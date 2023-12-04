using NuiN.ScriptableVariables.Core.Editor.Helpers;
using NuiN.ScriptableVariables.Internal.Helpers;
using NuiN.ScriptableVariables.Variable.References;
using UnityEditor;
using UnityEngine;

namespace NuiN.ScriptableVariables.Internal.Editor
{
#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(GetVariable<>))]
    internal class VariableReaderDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) 
            => SOReferenceGUIHelper.VarRefGUI(SOType.ScriptableVariable, Access.Getter, "variable", position, property, label, fieldInfo);

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) 
            => SOReferenceGUIHelper.GetPropertyHeight(property, label);
    }

    [CustomPropertyDrawer(typeof(SetVariable<>))]
    internal class VariableWriterDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
            => SOReferenceGUIHelper.VarRefGUI(SOType.ScriptableVariable, Access.Setter, "variable", position, property, label, fieldInfo);
        
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) 
            => SOReferenceGUIHelper.GetPropertyHeight(property, label);
    }
#endif
}

