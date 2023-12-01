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
        
        [Header("References")]
        [ReadOnly] [SerializeField] int total;
        [SerializeField] ReferencesContainer<ScriptableVariableReferenceBase<T>> references = 
            new(typeof(VariableReader<T>), typeof(VariableWriter<T>), "variable");
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

        void Reset() => references.FindObjectsAndAssignReferences(this, FindObjectsByType<GameObject>(FindObjectsSortMode.None), out total);


        void ResetValueOnStoppedPlaying(PlayModeStateChange state)
        {
            if (!resetOnExitPlaymode) return;
            if (state == PlayModeStateChange.EnteredEditMode) value = _startValue;
        }

        void OnSelectedInProjectWindow()
        {
            if (Selection.activeObject != this) return;
            references.FindObjectsAndAssignReferences(this, FindObjectsByType<GameObject>(FindObjectsSortMode.None), out total);
        }
#endif
    }
}
