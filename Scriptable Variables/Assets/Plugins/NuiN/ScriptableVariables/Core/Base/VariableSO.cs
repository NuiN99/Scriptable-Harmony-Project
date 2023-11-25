

namespace NuiN.ScriptableVariables.Base
{
    using System.Collections.Generic;
    using System.Linq;
    using UnityEditor;
    using UnityEngine;
    using System;
    using Object = UnityEngine.Object;

    public class VariableSO<T> : ScriptableObject
    {
        public T value;
        public bool onChangeEvents;
        public Action<T> onChange;
        
#if UNITY_EDITOR
        
        [SerializeField] bool keepRuntimeValues;
        
        [Space(25)]
        
        [SerializeField] List<Object> prefabReferences;
        [SerializeField] List<Object> sceneReferences;
        
        T _startValue;
        
        void OnEnable()
        {
            EditorApplication.playModeStateChanged += PlayModeChanged;
            Selection.selectionChanged += OnSelected;
        }
        void OnDisable()
        {
            EditorApplication.playModeStateChanged -= PlayModeChanged;
            Selection.selectionChanged -= OnSelected;
        }

        void PlayModeChanged(PlayModeStateChange state)
        {
            if (keepRuntimeValues) return;
            
            switch (state)
            {
                case PlayModeStateChange.ExitingEditMode: _startValue = value; break;
                case PlayModeStateChange.EnteredEditMode: value = _startValue; break;
            }
        }

        void OnSelected()
        {
            if (Selection.activeObject != this) return;
            SetReferences();
        }

        public void SetReferences()
        {
            string[] guids = AssetDatabase.FindAssets( "t:Prefab" );
            GameObject[] allPrefabs = guids.Select(guid =>
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                return AssetDatabase.LoadAssetAtPath<GameObject>(path);
            }).ToArray();
            
            GameObject[] allGameObjects = FindObjectsOfType<GameObject>();
            
            sceneReferences = FindReferencesInGameObjects(allGameObjects);
            prefabReferences = FindReferencesInGameObjects(allPrefabs);
        }

        List<Object> FindReferencesInGameObjects(IEnumerable<GameObject> objects)
        {
            List<Object> references = new();
            foreach (var obj in objects)
            {
                Component[] components = obj.GetComponents<Component>();

                foreach (var component in components)
                {
                    if (!component) continue;

                    var serializedObject = new SerializedObject(component);
                    var serializedProperty = serializedObject.GetIterator();

                    while (serializedProperty.NextVisible(true))
                    {
                        if (serializedProperty.propertyType != SerializedPropertyType.ObjectReference || serializedProperty.objectReferenceValue != this) continue;
                        references.Add(component.gameObject);
                    }
                }
            }

            return references;
        }
#endif
    }
}
