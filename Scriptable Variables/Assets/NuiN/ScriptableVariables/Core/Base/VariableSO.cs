using NuiN.ScriptableVaraibles.Lifetime;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using System;
using NuiN.ScriptableVariables.Editor.Attributes;
using Component = UnityEngine.Component;
using Object = UnityEngine.Object;

namespace NuiN.ScriptableVariables.Base
{
    public class VariableSO<T> : ScriptableObject
    {
#if UNITY_EDITOR
        [SerializeField] [TextArea] string description; 
#endif
        
        T _startValue;
        public T value;
        public bool onChangeEvent;
        public bool onChangeHistoryEvent;
        public Action<T> onChange;
        public Action<T,T> onChangeHistory;
        
        [Tooltip("Should it keep its value after loading a scene?")]
        [SerializeField] bool resetOnSceneLoad = true;
        
#if UNITY_EDITOR
        [Tooltip("Should it keep its value after exiting Playmode?")]
        [SerializeField] bool resetOnExitPlaymode = true;

        
        [Header("References")]
        [ReadOnly] [SerializeField] int total;
        [SerializeField] ReferenceLists objects;
#endif
        
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
            if (!resetOnSceneLoad) return;
            value = _startValue;
        }
        
#if UNITY_EDITOR
        
        void ResetValueOnStoppedPlaying(PlayModeStateChange state)
        {
            if (!resetOnExitPlaymode) return;
            if (state == PlayModeStateChange.EnteredEditMode) value = _startValue;
        }

        void OnSelectedInProjectWindow()
        {
            if (Selection.activeObject != this) return;
            FindObjectsAndAssignReferences();
            total = objects.TotalReferencesCount;
        }

        public void FindObjectsAndAssignReferences()
        {
            objects.Clear();
            
            string[] guids = AssetDatabase.FindAssets( "t:Prefab" );
            GameObject[] allPrefabs = guids.Select(guid =>
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                return AssetDatabase.LoadAssetAtPath<GameObject>(path);
            }).ToArray();
            
            GameObject[] allGameObjects = FindObjectsOfType<GameObject>();

            AssignReferences(allPrefabs, ref objects._readers, ref objects._writers, true);
            AssignReferences(allGameObjects, ref objects.readers, ref objects.writers, false);
        }

        void AssignReferences(IEnumerable<GameObject> foundObjects, ref List<Component> readers, ref List<Component> writers, bool prefabs)
        {
            foreach (var obj in foundObjects)
            {
                Component[] components = prefabs ? obj.GetComponentsInChildren<Component>() : obj.GetComponents<Component>();

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
    }
    
    [Serializable]
    internal class ReferenceLists
    {
        [Header("Prefabs")]
        // ReSharper disable once InconsistentNaming
        public List<Component> _writers = new();
        // ReSharper disable once InconsistentNaming
        public List<Component> _readers = new();
        
        [Header("Scene")]
        public List<Component> writers = new();
        public List<Component> readers = new();
        
        public int TotalReferencesCount => _writers.Count + _readers.Count + writers.Count + readers.Count;

        public void Clear()
        {
            _readers?.Clear();
            _writers?.Clear();
            readers?.Clear();
            writers?.Clear();
        }
    }
    
#endif
}
