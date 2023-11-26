using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace NuiN.ScriptableVariables.Editor
{
    public abstract class ReferenceVariableDrawerBase : PropertyDrawer
    {
        protected abstract SerializedProperty GetVariableProperty(SerializedProperty property);

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SerializedProperty variableProperty = GetVariableProperty(property);
            if (variableProperty.objectReferenceValue == null) return EditorGUIUtility.singleLineHeight * 2.25f;
            return EditorGUIUtility.singleLineHeight;
        }

        static string GetReadableTypeName(Type type)
        {
            return type switch
            {
                not null when type == typeof(float) => "Float",
                not null when type == typeof(bool) => "Bool",
                not null when type == typeof(int) => "Int",
                not null when type == typeof(long) => "Long",
                _ => type?.Name
            };
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            SerializedProperty variableProperty = GetVariableProperty(property);

            if (variableProperty.objectReferenceValue == null)
            {
                position.y += EditorGUIUtility.singleLineHeight * 1.25f;
            }

            string readWriteLabelPrefix = variableProperty.name switch
            {
                "readReference" => $"Read",
                "writeReference" => $"Write",
                _ => ""
            };
            label.text = $"{readWriteLabelPrefix}: {label.text}";

            Color labelTextColor = variableProperty.name switch
            {
                "readReference" => Color.blue,
                "writeReference" => Color.red,
                _ => Color.white
            };

            Type variableType = fieldInfo.FieldType.GetGenericArguments()[0];
            string typeName = GetReadableTypeName(variableType);

            if (variableType.IsGenericType && variableType.GetGenericTypeDefinition() == typeof(List<>))
            {
                Type listType = variableType.GetGenericArguments()[0];
                typeName = $"{GetReadableTypeName(listType)}List";
            }
            else if (variableType.IsArray)
            {
                Type arrayType = variableType.GetElementType();
                typeName = $"{GetReadableTypeName(arrayType)}Array";
            }
            typeName = $"{typeName}SO";
            
            EditorStyles.label.normal.textColor = labelTextColor;

            Rect objectFieldPosition = new Rect(position.x, position.y, position.width - EditorGUIUtility.singleLineHeight, EditorGUIUtility.singleLineHeight);
            
            EditorGUI.BeginProperty(objectFieldPosition, GUIContent.none, variableProperty);
            EditorGUI.PropertyField(objectFieldPosition, variableProperty, label, true);
            EditorGUI.EndProperty();
            

            Rect buttonPosition = new Rect(position.x + position.width - EditorGUIUtility.singleLineHeight, position.y, EditorGUIUtility.singleLineHeight, EditorGUIUtility.singleLineHeight);

            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            
            GUIContent buttonText = new GUIContent("^");

            Color originalColor = GUI.backgroundColor;
            GUI.backgroundColor = new Color(0.4f, 0.4f, 0.8f, 1.0f);
            if (GUI.Button(buttonPosition, buttonText, buttonStyle))
            {
                ScriptableVariableFinder.OpenFindWindow(typeName, variableProperty);
            }
            GUI.backgroundColor = originalColor;
            
            if (variableProperty.objectReferenceValue == null)
            {
                float labelWidth = EditorGUIUtility.labelWidth;
                float helpBoxWidth = position.width - labelWidth; // Calculate the width excluding the label

                Rect helpBoxPosition = new Rect(position.x + labelWidth, position.y - EditorGUIUtility.singleLineHeight, helpBoxWidth, EditorGUIUtility.singleLineHeight);
                EditorGUI.HelpBox(helpBoxPosition, $"Missing Variable: {typeName}", MessageType.Warning);
            }

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
