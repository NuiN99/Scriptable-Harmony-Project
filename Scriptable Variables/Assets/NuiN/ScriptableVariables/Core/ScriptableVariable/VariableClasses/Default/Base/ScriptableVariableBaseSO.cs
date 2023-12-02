using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine;
using System;
using NuiN.ScriptableVariables.Core.Attributes;
using NuiN.ScriptableVariables.Core.InternalHelpers;
using NuiN.ScriptableVariables.Variable.References;
using NuiN.ScriptableVariables.Variable.References.Base;

namespace NuiN.ScriptableVariables.Core.Variable.SOClasses.Base
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
        
        [Header("Value Persistence")]
        [SerializeField] bool resetOnSceneLoad = true;
#if UNITY_EDITOR
        [SerializeField] bool resetOnExitPlaymode = true;
        
        [Header("References In Project")]
        [ReadOnly] [SerializeField] int total;
        [SerializeField] ReadWriteReferencesContainer readersAndWriters = 
            new("variable", typeof(ScriptableVariableReferenceBase<T>), typeof(VariableReader<T>), typeof(VariableWriter<T>));
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

        void Reset() => AssignDebugReferences();
        
        void ResetValueOnStoppedPlaying(PlayModeStateChange state)
        {
            if (!resetOnExitPlaymode) return;
            if (state == PlayModeStateChange.EnteredEditMode) value = _startValue;
        }

        void OnSelectedInProjectWindow()
        {
            readersAndWriters?.Clear();
            if (Selection.activeObject != this) return;
            AssignDebugReferences();
        }
        
        void AssignDebugReferences()
        {
            GameObject[] sceneObjs = FindObjectsByType<GameObject>(FindObjectsSortMode.None);
            readersAndWriters.FindObjectsAndAssignReferences(this, sceneObjs, out total);
        }
#endif
    }
}