namespace NuiN.ScriptableVariables.Base
{
    using UnityEngine.SceneManagement;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEditor;
    using UnityEngine;
    using System;
    using Object = UnityEngine.Object;

    public class VariableSO<T> : ScriptableObject
    {
        T _startValue;
        
        public T value;
        public bool onChangeEvents;
        public Action<T> onChange;
        
        [SerializeField] bool keepValueThroughScenes;
        
#if UNITY_EDITOR
        [SerializeField] bool keepPlayModeValue;
        
        [Space(25)]
        
        [SerializeField] List<Object> prefabReferences;
        [SerializeField] List<Object> sceneReferences;
#endif
        void OnEnable()
        {
            GameLoadedEvent.OnGameLoaded += GameStarted;
            SceneManager.activeSceneChanged += SceneLoaded;
#if UNITY_EDITOR
            EditorApplication.playModeStateChanged += PlayModeChanged;
            Selection.selectionChanged += OnSelected;
#endif
        }
        void OnDisable()
        {
            GameLoadedEvent.OnGameLoaded -= GameStarted;
            SceneManager.activeSceneChanged -= SceneLoaded;
#if UNITY_EDITOR
            EditorApplication.playModeStateChanged -= PlayModeChanged;
            Selection.selectionChanged -= OnSelected;
#endif
        }
        
        void GameStarted()
        {
            _startValue = value;
        }

        void SceneLoaded(Scene scene, Scene scene2)
        {
            if (keepValueThroughScenes) return;
            value = _startValue;
        }
        
#if UNITY_EDITOR
        
        void PlayModeChanged(PlayModeStateChange state)
        {
            if (keepPlayModeValue) return;
            if (state == PlayModeStateChange.EnteredEditMode) value = _startValue;
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
