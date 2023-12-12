using NuiN.ScriptableHarmony.Internal.Helpers;
using UnityEditor;
using UnityEngine;
// ReSharper disable InconsistentNaming

namespace NuiN.ScriptableHarmony.Editor
{
    [CustomPropertyDrawer(typeof(GetSetReferencesContainer))]
    internal class ReadWriteReferencesContainerDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            SerializedProperty getters = property.FindPropertyRelative("getters");
            SerializedProperty setters = property.FindPropertyRelative("setters");
            SerializedProperty Getters = property.FindPropertyRelative("Getters");
            SerializedProperty Setters = property.FindPropertyRelative("Setters");

            int totalReferencesCount = getters.arraySize + setters.arraySize + Getters.arraySize + Setters.arraySize;

            property.isExpanded = EditorGUI.Foldout(
                new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight),
                property.isExpanded, $"Total References: {totalReferencesCount}");

            if (property.isExpanded)
            {
                EditorGUI.indentLevel++;

                float lineHeight = EditorGUIUtility.singleLineHeight;
                float startY = position.y + lineHeight;

                startY = DrawReadOnlyList(new Rect(position.x, startY, position.width, lineHeight), "Getters", Getters);
                startY = DrawReadOnlyList(new Rect(position.x, startY, position.width, lineHeight), "Setters", Setters);
                startY = DrawReadOnlyList(new Rect(position.x, startY, position.width, lineHeight), "getters", getters);
                DrawReadOnlyList(new Rect(position.x, startY, position.width, lineHeight), "setters", setters);

                EditorGUI.indentLevel--;
            }

            EditorGUI.EndProperty();
        }

        static float DrawReadOnlyList(Rect rect, string label, SerializedProperty list)
        {
            EditorGUI.BeginDisabledGroup(true);
            EditorGUI.PropertyField(rect, list, new GUIContent(label), true);
            EditorGUI.EndDisabledGroup();
            return rect.y + EditorGUI.GetPropertyHeight(list, true);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float height = EditorGUIUtility.singleLineHeight;
            if (!property.isExpanded) return height;
            
            height += GetListHeight(property.FindPropertyRelative("getters"));
            height += GetListHeight(property.FindPropertyRelative("setters"));
            height += GetListHeight(property.FindPropertyRelative("Getters"));
            height += GetListHeight(property.FindPropertyRelative("Setters"));
            return height;
        }

        static float GetListHeight(SerializedProperty list)
        {
            return EditorGUI.GetPropertyHeight(list, true);
        }
    }
}

