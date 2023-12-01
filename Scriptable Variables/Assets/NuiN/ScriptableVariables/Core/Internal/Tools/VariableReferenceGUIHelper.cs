using System;
using System.Collections.Generic;
using System.Reflection;
using NuiN.ScriptableVariables.References;
using NuiN.ScriptableVariables.Tools;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
    internal static class VariableReferenceGUIHelper
    {
        static readonly Color GetterColor = new(0.7f, 0.9f, 0.95f, 1f);
        static readonly Color SetterColor = new(0.9f, 0.7f, 0.7f, 1f);
        static readonly Color OverlayColor = new(0.1f, 0.1f, 0.1f, 1);

        public static float GetPropertyHeight(SerializedProperty property, GUIContent label) 
            => EditorGUIUtility.singleLineHeight;

        public static void VarRefGUI(Access accessType, string propertyName, Rect position, SerializedProperty property, GUIContent label, FieldInfo fieldInfo)
        {
            Color color = accessType switch { Access.Getter => GetterColor, Access.Setter => SetterColor, _ => Color.white };
            
            EditorGUI.BeginProperty(position, label, property);

            SerializedProperty variableProperty = property.FindPropertyRelative(propertyName);

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
                DrawLabel();
                DrawFindButton();
                DrawPropertyField();
                DrawHelpBox();
            }
            else
            {
                DrawPropertyField();
                DrawFindButton();
            }

            EditorGUI.EndProperty();
            return;

            void DrawFindButton()
            {
                Rect buttonPosition = new Rect(position.x + position.width - EditorGUIUtility.singleLineHeight, position.y, EditorGUIUtility.singleLineHeight, EditorGUIUtility.singleLineHeight);
                GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
                GUIContent buttonText = new GUIContent("^");
                Color originalColor = GUI.backgroundColor;
                GUI.backgroundColor = new Color(0.4f,0.4f,0.4f, 1);
                if (GUI.Button(buttonPosition, buttonText, buttonStyle))
                {
                    ScriptableVariableFinder.OpenFindWindow(typeName, variableProperty);
                }
                GUI.backgroundColor = originalColor;
            }

            void DrawHelpBox()
            {
                position.y += EditorGUIUtility.singleLineHeight;
                float labelWidth = EditorGUIUtility.labelWidth + 2.5f;
                float helpBoxWidth = position.width - labelWidth - EditorGUIUtility.singleLineHeight; // Adjust width to make room for the button
                Rect helpBoxPosition = new Rect(position.x + labelWidth, position.y - EditorGUIUtility.singleLineHeight, helpBoxWidth, EditorGUIUtility.singleLineHeight);
                EditorGUI.DrawRect(helpBoxPosition, OverlayColor);
                EditorGUI.HelpBox(helpBoxPosition, $"None ({typeName})", MessageType.Warning);
            }

            void DrawLabel()
            {
                EditorStyles.label.normal.textColor = color;
                Rect labelPosition = new Rect(position.x, position.y, position.width - EditorGUIUtility.singleLineHeight, EditorGUIUtility.singleLineHeight);
                EditorGUI.LabelField(labelPosition, label);
                EditorStyles.label.normal.textColor = Color.white;
            }

            void DrawPropertyField()
            {
                Rect objectFieldPosition = new Rect(position.x, position.y, position.width - EditorGUIUtility.singleLineHeight, EditorGUIUtility.singleLineHeight);
                EditorStyles.label.normal.textColor = color;
                EditorGUI.BeginProperty(objectFieldPosition, GUIContent.none, variableProperty);
                EditorGUI.PropertyField(objectFieldPosition, variableProperty, label, true);
                EditorGUI.EndProperty();
                EditorStyles.label.normal.textColor = Color.white;
            }
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
    }
    #endif