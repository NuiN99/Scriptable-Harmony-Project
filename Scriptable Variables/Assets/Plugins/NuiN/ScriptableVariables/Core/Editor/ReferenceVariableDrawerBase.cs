using System.Collections;
using System.Collections.Generic;

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

        string GetReadableTypeName(Type type)
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
            
            if (variableProperty.objectReferenceValue == null)
            {
                Rect helpBoxPosition = new Rect(position.x + position.width / 2.33f, position.y, position.width / 1.75f, EditorGUIUtility.singleLineHeight);
                EditorGUI.HelpBox(helpBoxPosition, $"Missing Variable: {typeName}", MessageType.Warning);
            }
            
            if (GUILayout.Button("Find Variable"))
            {
                ScriptableVariableFinder.OpenFindWindow(typeName, variableProperty);
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
    