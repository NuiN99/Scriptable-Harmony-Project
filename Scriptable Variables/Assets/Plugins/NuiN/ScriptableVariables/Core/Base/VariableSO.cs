namespace NuiN.ScriptableVariables.Base
{
    using System.Collections.Generic;
    using System.Linq;
    using UnityEditor;
    using UnityEngine;

    public class VariableSO<T> : ScriptableObject
    {
        public T value;
        
#if UNITY_EDITOR
        
        T _startValue;
        [SerializeField] bool keepRuntimeValues;
        
        [Header("Prefab References")]
        [SerializeField] List<Object> prefabReferences; 
        
        [Header("Scene References")]
        [SerializeField] List<Object> sceneReferences; 
        
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
            FindReferences();
        }

        public void FindReferences()
        {
            string[] guids = AssetDatabase.FindAssets( "t:Prefab" );
            GameObject[] allPrefabs = guids.Select(guid =>
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                return AssetDatabase.LoadAssetAtPath<GameObject>(path);
            }).ToArray();
            
            GameObject[] allGameObjects = FindObjectsOfType<GameObject>();
            
            sceneReferences = GetReferencesInGameObjectArray(allGameObjects);
            prefabReferences = GetReferencesInGameObjectArray(allPrefabs);
        }

        List<Object> GetReferencesInGameObjectArray(IEnumerable<GameObject> objects)
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
