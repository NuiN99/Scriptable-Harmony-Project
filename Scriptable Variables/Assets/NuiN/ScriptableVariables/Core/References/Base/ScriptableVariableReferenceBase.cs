using System;
using System.Collections.Generic;
using System.Reflection;
using NuiN.ScriptableVariables.Core.Base;
using NuiN.ScriptableVariables.Tools;
using UnityEditor;
using UnityEngine;

namespace NuiN.ScriptableVariables.References.Base
{
    [Serializable]
    public class ScriptableVariableReferenceBase<T>
    {
        [SerializeField] protected ScriptableVariableBaseSO<T> variable;
        
        public void SubOnChange(Action<T> onChange) => variable.onChange += onChange;
        public void UnsubOnChange(Action<T> onChange) => variable.onChange -= onChange;

        public void SubOnChangeWithOld(Action<T, T> onChangeWithOld) => variable.onChangeWithOld += onChangeWithOld;
        public void UnsubOnChangeWithOld(Action<T, T> onChangeWithOld) => variable.onChangeWithOld -= onChangeWithOld;
    }
    
#if UNITY_EDITOR
    internal static class VariableReferenceGUIHelper
    {
        public static Color getterColor = new Color(0.7f, 0.9f, 0.95f, 1f);
        public static Color setterColor = new Color(0.9f, 0.7f, 0.7f, 1f);
        
        static SerializedProperty GetVariableProperty(SerializedProperty property)
            => property.FindPropertyRelative("variable");

        public static void VarRefGUI(Rect position, SerializedProperty property, GUIContent label, Color color, FieldInfo fieldInfo)
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
                DrawLabel();
                DrawFindButton();
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
                float labelWidth = EditorGUIUtility.labelWidth;
                float helpBoxWidth = position.width - labelWidth - EditorGUIUtility.singleLineHeight; // Adjust width to make room for the button
                Rect helpBoxPosition = new Rect(position.x + labelWidth, position.y - EditorGUIUtility.singleLineHeight, helpBoxWidth, EditorGUIUtility.singleLineHeight);
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
    
    [CustomPropertyDrawer(typeof(GetVar<>))]
    internal class GetVarDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) 
            => VariableReferenceGUIHelper.VarRefGUI(position, property, label, VariableReferenceGUIHelper.getterColor, fieldInfo);
        
    }
    
    [CustomPropertyDrawer(typeof(SetVar<>))]
    internal class SetVarDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
            => VariableReferenceGUIHelper.VarRefGUI(position, property, label, VariableReferenceGUIHelper.setterColor, fieldInfo);
    }
    #endif
}
