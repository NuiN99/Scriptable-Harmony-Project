using NuiN.ScriptableVariables.References;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(VariableReader<>))]
internal class VariableReaderDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) 
        => SOReferenceGUIHelper.VarRefGUI(SOType.ScriptableVariable, Access.Getter, "variable", position, property, label, fieldInfo);

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label) 
        => SOReferenceGUIHelper.GetPropertyHeight(property, label);
}

[CustomPropertyDrawer(typeof(VariableWriter<>))]
internal class VariableWriterDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        => SOReferenceGUIHelper.VarRefGUI(SOType.ScriptableVariable, Access.Setter, "variable", position, property, label, fieldInfo);
        
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label) 
        => SOReferenceGUIHelper.GetPropertyHeight(property, label);
}
