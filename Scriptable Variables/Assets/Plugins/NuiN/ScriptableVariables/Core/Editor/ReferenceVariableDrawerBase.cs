namespace NuiN.ScriptableVariables.Editor
{
    using System;
    using UnityEditor;
    using UnityEngine;

    public abstract class ReferenceVariableDrawerBase : PropertyDrawer
    {
        protected abstract SerializedProperty GetVariableProperty(SerializedProperty property);

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SerializedProperty variableProperty = GetVariableProperty(property);
            if(variableProperty.objectReferenceValue == null) 
            {
                return EditorGUIUtility.singleLineHeight * 2;
            }

            return EditorGUIUtility.singleLineHeight;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            SerializedProperty variableProperty = GetVariableProperty(property);

            if (variableProperty.objectReferenceValue == null)
            {
                Type variableType = fieldInfo.FieldType.GetGenericArguments()[0];
                string typeName = variableType switch
                {
                    not null when variableType == typeof(float) => "Float",
                    not null when variableType == typeof(bool) => "Bool",
                    not null when variableType == typeof(int) => "Int",
                    not null when variableType == typeof(long) => "Long",
                    _ => variableType.Name
                };

                Rect helpBoxPosition = new Rect(position.x + position.width / 2.33f, position.y, position.width / 1.75f, EditorGUIUtility.singleLineHeight);
                EditorGUI.HelpBox(helpBoxPosition, $"Missing {typeName}SO Variable", MessageType.Warning);
            }

            if (variableProperty.objectReferenceValue == null)
            {
                position.y += EditorGUIUtility.singleLineHeight;
            }
            
            string readWriteLabelPrefix = variableProperty.name switch
            {
                "readReference" => $"Read",
                "writeReference" => $"Write",
                _ => ""
            };
            label.text = $"{readWriteLabelPrefix}: {label.text}";

            EditorGUI.BeginProperty(position, GUIContent.none, variableProperty);
            EditorGUI.PropertyField(position, variableProperty, label, true);
            EditorGUI.EndProperty();
            EditorGUI.EndProperty();
        }
    }
    
    [CustomPropertyDrawer(typeof(ReadVariable<>))]
    public class ReadVariableDrawer : ReferenceVariableDrawerBase
    {
        protected override SerializedProperty GetVariableProperty(SerializedProperty property)
            => property.FindPropertyRelative("readReference");
    }

    [CustomPropertyDrawer(typeof(WriteVariable<>))]
    public class WriteVariableDrawer : ReferenceVariableDrawerBase
    {
        protected override SerializedProperty GetVariableProperty(SerializedProperty property)
            => property.FindPropertyRelative("writeReference");
    }  
}
    