using System;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using Object = UnityEngine.Object;

public class CustomObjectPickerWindow : EditorWindow
{
    List<Object> _foundObjects = new();
    static string _typeName;
    static SerializedProperty _property;

    private static CustomObjectPickerWindow _windowInstance;
    private Vector2 _scrollPosition;
    private string _searchFilter = "";

    public static void ShowWindow(string typeName, SerializedProperty property)
    {
        _property = property;
        _typeName = typeName;
        _windowInstance = GetWindow<CustomObjectPickerWindow>("Custom Object Picker");

        // Call FindObjects when the window is first created
        _windowInstance.FindObjects();
    }

    void OnEnable()
    {
        FindObjects();
        EditorApplication.update += CheckFocus;
    }

    void OnDestroy()
    {
        EditorApplication.update -= CheckFocus;
    }

    private void OnGUI()
    {
        GUILayout.Label("Object Picker", EditorStyles.boldLabel);

        // Create a horizontal layout for the search bar
        EditorGUILayout.BeginHorizontal();

        // Use EditorGUIUtility.IconContent for the magnifying glass icon
        GUIContent searchIcon = EditorGUIUtility.IconContent("Search Icon");

        GUILayout.Space(5); // Add space before the icon

        // Draw the icon and search bar on the same line
        EditorGUILayout.LabelField(searchIcon, GUILayout.Width(20));
        _searchFilter = EditorGUILayout.TextField(_searchFilter);

        EditorGUILayout.EndHorizontal();

        // Create a scroll view for the object list
        _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition);

        // Display found objects
        foreach (var obj in _foundObjects)
        {
            // Apply search filter
            if (!string.IsNullOrEmpty(_searchFilter) && !obj.name.Contains(_searchFilter, StringComparison.OrdinalIgnoreCase))
                continue;

            EditorGUILayout.BeginHorizontal();

            // Display the object name as a clickable label
            Rect labelRect = GUILayoutUtility.GetRect(new GUIContent(obj.name), EditorStyles.label);
            if (Event.current.type == EventType.MouseDown && labelRect.Contains(Event.current.mousePosition))
            {
                EditorGUIUtility.PingObject(obj);
                Event.current.Use();
            }

            EditorGUI.ObjectField(labelRect, GUIContent.none, obj, typeof(UnityEngine.Object), true);

            // Add a button to assign the object
            if (GUILayout.Button("Assign", GUILayout.Width(60)))
            {
                // When the button is clicked, assign the selected object to the SerializedProperty
                _property.objectReferenceValue = obj;
                // Apply modifications to the SerializedProperty
                _property.serializedObject.ApplyModifiedProperties();
                // Close the window
                Close();
            }

            EditorGUILayout.EndHorizontal();
        }

        EditorGUILayout.EndScrollView();
    }

    private void FindObjects()
    {
        _foundObjects.Clear();

        // Find all assets of the specified type
        string[] guids = AssetDatabase.FindAssets($"t:{_typeName}");

        foreach (var guid in guids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            Object obj = AssetDatabase.LoadAssetAtPath<Object>(assetPath);

            // Add the object to the list if it matches the specified type
            if (obj != null && obj.GetType().Name == _typeName)
            {
                _foundObjects.Add(obj);
            }
        }
    }

    // Check if the window has lost focus and close it if true
    private void CheckFocus()
    {
        if (EditorWindow.focusedWindow != _windowInstance)
        {
            Close();
        }
    }
}
