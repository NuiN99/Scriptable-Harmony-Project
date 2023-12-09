using NuiN.ScriptableVariables.Core.Editor.Helpers;
using NuiN.ScriptableVariables.Internal.Helpers;
using NuiN.ScriptableVariables.References;
using NuiN.ScriptableVariables.Variable.References;
using UnityEditor;
using UnityEngine;

namespace NuiN.ScriptableVariables.Internal.Editor
{
#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(GetVariable<>))]
    internal class GetVariableDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) 
            => SOReferenceGUIHelper.VarRefGUI(SOType.Variable, Access.Getter, "variable", position, property, label, fieldInfo);

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) 
            => SOReferenceGUIHelper.GetPropertyHeight(property, label);
    }

    [CustomPropertyDrawer(typeof(SetVariable<>))]
    internal class SetVariableDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
            => SOReferenceGUIHelper.VarRefGUI(SOType.Variable, Access.Setter, "variable", position, property, label, fieldInfo);
        
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) 
            => SOReferenceGUIHelper.GetPropertyHeight(property, label);
    }
#endif
}

