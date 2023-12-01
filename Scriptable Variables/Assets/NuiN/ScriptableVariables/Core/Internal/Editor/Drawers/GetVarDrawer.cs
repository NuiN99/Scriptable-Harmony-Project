using NuiN.ScriptableVariables.References;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(GetVar<>))]
internal class GetVarDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) 
        => VariableReferenceGUIHelper.VarRefGUI(Access.Getter, "variable", position, property, label, fieldInfo);

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label) 
        => VariableReferenceGUIHelper.GetPropertyHeight(property, label);
}

[CustomPropertyDrawer(typeof(SetVar<>))]
internal class SetVarDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        => VariableReferenceGUIHelper.VarRefGUI(Access.Setter, "variable", position, property, label, fieldInfo);
        
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label) 
        => VariableReferenceGUIHelper.GetPropertyHeight(property, label);
}
