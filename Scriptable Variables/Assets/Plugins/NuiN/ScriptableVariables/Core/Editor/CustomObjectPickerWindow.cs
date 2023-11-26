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

    public static void ShowWindow(string typeName, SerializedProperty property)
    {
        _property = property;
        _typeName = typeName;
        CustomObjectPickerWindow window = GetWindow<CustomObjectPickerWindow>("Custom Object Picker");

        // Call FindObjects when the window is first created
        window.FindObjects();
    }

    void OnEnable()
    {
        FindObjects();
    }

    private void OnGUI()
    {
        GUILayout.Label("Object Picker", EditorStyles.boldLabel);

        // Display found objects
        if (_foundObjects.Count > 0)
        {
            EditorGUILayout.LabelField("Found Objects:");
            foreach (var obj in _foundObjects)
            {
                // Display the object and an assign button
                EditorGUILayout.BeginHorizontal();

                // Display the object
                EditorGUILayout.ObjectField(obj, typeof(UnityEngine.Object), true);

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
        }
        else
        {
            EditorGUILayout.LabelField("No objects found.");
        }
    }

    private void FindObjects()
    {
        _foundObjects.Clear();

        // Find all objects in the scene
        UnityEngine.Object[] allObjects = Resources.FindObjectsOfTypeAll<Object>();

        // Filter based on the search string
        foreach (var obj in allObjects)
        {
            if (obj != null && obj.GetType().Name == _typeName)
            {
                _foundObjects.Add(obj);
            }
        }
    }
}
