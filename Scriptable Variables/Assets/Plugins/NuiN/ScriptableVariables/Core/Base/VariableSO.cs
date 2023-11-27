using NuiN.ScriptableVariables.Helper;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace NuiN.ScriptableVariables.Base
{
    public class VariableSO<T> : ScriptableObject
    {
        T _startValue;
        
        public T value;
        public bool invokeOnChangeEvent;
        public Action<T> onChange;
        
        [SerializeField] bool keepValueThroughScenes;
        
#if UNITY_EDITOR
        [SerializeField] bool keepPlayModeValue;
        
        [Space(25)]
        
        [Header("Prefabs")]
        [SerializeField] List<Object> prefabReaders;
        [SerializeField] List<Object> prefabWriters;
        
        [Header("Scene")]
        [SerializeField] List<Object> sceneReaders;
        [SerializeField] List<Object> sceneWriters;
        
#endif
        
        // playModeStateChanged and selectionChanged events only run in editor
        void OnEnable()
        {
            GameLoadedEvent.OnGameLoaded += CacheStartValueOnStart;
            SceneManager.activeSceneChanged += ResetValueOnSceneLoad;
#if UNITY_EDITOR
            EditorApplication.playModeStateChanged += ResetValueOnStoppedPlaying;
            Selection.selectionChanged += OnSelectedInProjectWindow;
#endif
        }
        void OnDisable()
        {
            GameLoadedEvent.OnGameLoaded -= CacheStartValueOnStart;
            SceneManager.activeSceneChanged -= ResetValueOnSceneLoad;
#if UNITY_EDITOR
            EditorApplication.playModeStateChanged -= ResetValueOnStoppedPlaying;
            Selection.selectionChanged -= OnSelectedInProjectWindow;
#endif
        }
        
        void CacheStartValueOnStart() =>  _startValue = value;

        void ResetValueOnSceneLoad(Scene scene, Scene scene2)
        {
            if (keepValueThroughScenes) return;
            value = _startValue;
        }
        
#if UNITY_EDITOR
        
        void ResetValueOnStoppedPlaying(PlayModeStateChange state)
        {
            if (keepPlayModeValue) return;
            if (state == PlayModeStateChange.EnteredEditMode) value = _startValue;
        }

        void OnSelectedInProjectWindow()
        {
            if (Selection.activeObject != this) return;
            FindObjectsAndAssignReferences();
        }

        public void FindObjectsAndAssignReferences()
        {
            prefabReaders.Clear();
            prefabWriters.Clear();
            sceneReaders.Clear();
            sceneWriters.Clear();
            
            string[] guids = AssetDatabase.FindAssets( "t:Prefab" );
            GameObject[] allPrefabs = guids.Select(guid =>
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                return AssetDatabase.LoadAssetAtPath<GameObject>(path);
            }).ToArray();
            
            GameObject[] allGameObjects = FindObjectsOfType<GameObject>();
            
            AssignReferences(allPrefabs, ref prefabReaders, ref prefabWriters);
            AssignReferences(allGameObjects, ref sceneReaders, ref sceneWriters);
        }

        void AssignReferences(IEnumerable<GameObject> objects, ref List<Object> readers, ref List<Object> writers)
        {
            foreach (var obj in objects)
            {
                Component[] components = obj.GetComponentsInChildren<Component>();

                foreach (var component in components)
                {
                    if (!component) continue;

                    var serializedObject = new SerializedObject(component);
                    var serializedProperty = serializedObject.GetIterator();
                    while (serializedProperty.NextVisible(true))
                    {
                        if (serializedProperty.propertyType != SerializedPropertyType.ObjectReference || serializedProperty.objectReferenceValue != this) continue;

                        string propertyName = serializedProperty.name.ToUpper();
                        
                        if (propertyName.Contains("READ")) readers.Add(component);
                        else if (propertyName.Contains("WRITE")) writers.Add(component);
                    }
                }
            }
        }
#endif
    }
}
