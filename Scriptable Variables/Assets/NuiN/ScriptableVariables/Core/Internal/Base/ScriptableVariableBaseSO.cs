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
        
        public Action<T> onChange;
        public Action<T,T> onChangeWithOld;
        
        [Tooltip("Should it keep its value after loading a scene?")]
        [SerializeField, Header("Value Persistence")] bool resetOnSceneLoad = true;
#if UNITY_EDITOR
        [Tooltip("Should it keep its value after exiting Playmode?")]
        [SerializeField] bool resetOnExitPlaymode = true;
        
        [Header("Components")]
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

        void Reset() => FindObjectsAndAssignReferences();

        void ResetValueOnStoppedPlaying(PlayModeStateChange state)
        {
            if (!resetOnExitPlaymode) return;
            if (state == PlayModeStateChange.EnteredEditMode) value = _startValue;
        }

        void OnSelectedInProjectWindow()
        {
            if (Selection.activeObject != this) return;
            FindObjectsAndAssignReferences();
        }

        public void FindObjectsAndAssignReferences()
        {
            if (objects == null) return;
            objects.Clear();
            
            string[] guids = AssetDatabase.FindAssets( "t:Prefab" );
            GameObject[] allPrefabs = guids.Select(guid =>
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                return AssetDatabase.LoadAssetAtPath<GameObject>(path);
            }).ToArray();
            
            GameObject[] allGameObjects = FindObjectsOfType<GameObject>();

            AssignReferences(allPrefabs, ref objects.Getters, ref objects.Setters, true);
            AssignReferences(allGameObjects, ref objects.getters, ref objects.setters, false);

            if (objects.ListsAreNull) return;
            total = objects.TotalReferencesCount;
        }

        void AssignReferences(IEnumerable<GameObject> foundObjects, ref List<Component> getters, ref List<Component> setters, bool prefabs)
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
                        
                        bool isGetter = type == typeof(GetVar<T>);
                        bool isSetter = type == typeof(SetVar<T>);
                        
                        if(!isGetter && !isSetter) continue;

                        if (field.GetValue(component) is not ScriptableVariableReferenceBase<T> variableField) continue;
                        
                        FieldInfo variableFieldInfo = typeof(ScriptableVariableReferenceBase<T>).GetField("variable", BindingFlags.Instance | BindingFlags.NonPublic);

                        if (variableFieldInfo == null || !ReferenceEquals(variableFieldInfo.GetValue(variableField), this)) continue;
                        
                        if (isGetter) getters.Add(component);
                        else setters.Add(component);
                    }
                }
            }
        }
#endif
    }
}
