using System;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;
using NuiN.ScriptableVariables.Base;
using Object = UnityEngine.Object;

namespace NuiN.ScriptableVariables.Editor
{
    public class ScriptableVariableFinder : EditorWindow
    {
        List<Object> _foundObjects = new();
        Vector2 _scrollPosition;
        static string _typeName;
        static SerializedProperty _property;
        string _searchFilter;
        static ScriptableVariableFinder _windowInstance;

        public static void OpenFindWindow(string typeName, SerializedProperty property)
        {
            _property = property;
            _typeName = typeName;
            _windowInstance = GetWindow<ScriptableVariableFinder>("Scriptable Variable Finder");

            _windowInstance.FindObjects();
        }

        void OnEnable()
        {
            FindObjects();
            EditorApplication.update += CheckFocus;
        }

        void OnDestroy() => EditorApplication.update -= CheckFocus;

        void OnGUI()
        {
            EditorGUILayout.BeginHorizontal();

            GUIContent searchIcon = EditorGUIUtility.IconContent("Search Icon");

            GUILayout.Space(5);

            EditorGUILayout.LabelField(searchIcon, GUILayout.Width(20));
            _searchFilter = EditorGUILayout.TextField(_searchFilter);

            EditorGUILayout.EndHorizontal();

            _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition);

            foreach (Object obj in _foundObjects.Where(obj =>
                         string.IsNullOrEmpty(_searchFilter) ||
                         obj.name.Contains(_searchFilter, StringComparison.OrdinalIgnoreCase)))
            {
                EditorGUILayout.BeginHorizontal();

                Rect labelRect = GUILayoutUtility.GetRect(new GUIContent(obj.name), EditorStyles.label);
                if (Event.current.type == EventType.MouseDown && labelRect.Contains(Event.current.mousePosition))
                {
                    EditorGUIUtility.PingObject(obj);
                    Event.current.Use();
                }

                EditorGUI.ObjectField(labelRect, GUIContent.none, obj, typeof(VariableSO<>), true);
                GUIStyle style = new GUIStyle(GUI.skin.button) { normal = { textColor = Color.black } };
                if (GUILayout.Button("Assign", style, GUILayout.Width(60)))
                {
                    _property.objectReferenceValue = obj;
                    _property.serializedObject.ApplyModifiedProperties();
                    Close();
                }

                EditorGUILayout.EndHorizontal();
            }
            
            EditorGUILayout.EndScrollView();
        }

        void FindObjects()
        {
            _foundObjects.Clear();

            string[] guids = AssetDatabase.FindAssets($"t:{_typeName}");

            foreach (var guid in guids)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guid);
                Object obj = AssetDatabase.LoadAssetAtPath<Object>(assetPath);

                if (obj != null && obj.GetType().Name == _typeName) _foundObjects.Add(obj);
            }
        }

        void CheckFocus()
        {
            if (EditorWindow.focusedWindow != _windowInstance) Close();
        }
    }
}

