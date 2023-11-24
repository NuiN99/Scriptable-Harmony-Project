namespace NuiN.ScriptableVariables.Editor
{
    using System;
    using UnityEditor;
    using UnityEngine;

    public abstract class ReferenceVariableDrawerBase : PropertyDrawer
    {
        protected abstract SerializedProperty GetVariableProperty(SerializedProperty property);

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) 
            => EditorGUI.GetPropertyHeight(property);

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
                    _ => variableType.Name
                };

                Rect helpBoxPosition = new Rect(position.x + position.width / 2f, position.y, position.width / 2f, EditorGUIUtility.singleLineHeight);
                EditorGUI.HelpBox(helpBoxPosition, $"Missing {typeName}SO", MessageType.Warning);
            }

            bool isExpanded = EditorGUI.PropertyField(position, property, label, true);
            if (isExpanded)
            {
                EditorGUI.indentLevel++;

                float propertyHeight = EditorGUI.GetPropertyHeight(property);

                position.height += propertyHeight + EditorGUI.GetPropertyHeight(property);

                position.y += EditorGUIUtility.singleLineHeight;
                EditorGUI.PropertyField(position, variableProperty, label, true);
                EditorGUI.indentLevel--;
            }

            EditorGUI.EndProperty();
        }
    }
    
    [CustomPropertyDrawer(typeof(ReadVariable<>))]
    public class ReadVariableDrawer : ReferenceVariableDrawerBase
    {
        protected override SerializedProperty GetVariableProperty(SerializedProperty property)
        {
            ReadVariable<object> classInstance = new();
            return property.FindPropertyRelative("readReference");
        }
    }

    [CustomPropertyDrawer(typeof(WriteVariable<>))]
    public class WriteVariableDrawer : ReferenceVariableDrawerBase
    {
        protected override SerializedProperty GetVariableProperty(SerializedProperty property)
        {
            return property.FindPropertyRelative("writeReference");
        }
    }  
}



