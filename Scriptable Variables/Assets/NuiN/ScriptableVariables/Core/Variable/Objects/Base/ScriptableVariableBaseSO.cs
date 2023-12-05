using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine;
using System;
using NuiN.ScriptableVariables.Internal.Attributes;
using NuiN.ScriptableVariables.Internal.Helpers;
using NuiN.ScriptableVariables.References;
using NuiN.ScriptableVariables.Variable.References;
using NuiN.ScriptableVariables.Variable.References.Base;

namespace NuiN.ScriptableVariables.Variable.Base
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
        [SerializeField] ReadWriteReferencesContainer gettersAndSetters = 
            new("variable", typeof(ReferenceScriptableVariableBase<T>), typeof(GetVariable<T>), typeof(SetVariable<T>));
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
            gettersAndSetters?.Clear();
            if (Selection.activeObject != this) return;
            AssignDebugReferences();
        }
        
        void AssignDebugReferences()
        {
            GameObject[] sceneObjs = FindObjectsByType<GameObject>(FindObjectsSortMode.None);
            gettersAndSetters.FindObjectsAndAssignReferences(this, sceneObjs, out total);
        }
#endif
    }
}
