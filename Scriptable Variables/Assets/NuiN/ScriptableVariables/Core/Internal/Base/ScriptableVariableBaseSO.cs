using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using System;
using System.Reflection;
using NuiN.ScriptableVariables.Editor.Attributes;
using NuiN.ScriptableVariables.References;
using NuiN.ScriptableVariables.References.Base;
using Component = UnityEngine.Component;

namespace NuiN.ScriptableVariables.Core.Base
{
    public class ScriptableVariableBaseSO<T> : ScriptableObject
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

                    Type componentType = component.GetType();

                    FieldInfo[] fields = componentType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                    foreach (var field in fields)
                    {
                        Type type = field.FieldType;
                        if (!type.IsGenericType) continue;
                        
                        bool isRead = type == typeof(ReadVariable<T>);
                        bool isWrite = type == typeof(WriteVariable<T>);
                        
                        if(!isRead && !isWrite) continue;

                        if (field.GetValue(component) is not ScriptableVariableReferenceBase<T> variableField) continue;
                        
                        FieldInfo variableFieldInfo = typeof(ScriptableVariableReferenceBase<T>).GetField("variable", BindingFlags.Instance | BindingFlags.NonPublic);

                        if (variableFieldInfo == null || !ReferenceEquals(variableFieldInfo.GetValue(variableField), this)) continue;
                        
                        if (isRead) readers.Add(component);
                        else writers.Add(component);
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
        public List<Component> _writers;
        // ReSharper disable once InconsistentNaming
        public List<Component> _readers;
        
        [Header("Scene")]
        public List<Component> writers;
        public List<Component> readers;
        
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
