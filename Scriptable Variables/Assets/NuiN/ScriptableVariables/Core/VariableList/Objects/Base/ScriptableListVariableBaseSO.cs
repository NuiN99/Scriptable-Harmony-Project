using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;
using NuiN.ScriptableVariables.Internal.Attributes;
using NuiN.ScriptableVariables.Internal.Helpers;
using NuiN.ScriptableVariables.ListVariable.References.Base;
using NuiN.ScriptableVariables.References;

namespace NuiN.ScriptableVariables.ListVariable.Base
{
    public class ScriptableListVariableBaseSO<T> : ScriptableObject
    {
        [SerializeField] [TextArea] string description; 
        
        List<T> _startValue = new();
        public List<T> list = new();
        
        public Action<List<T>> onSet;
        public Action<List<T>, List<T>> onSetWithOld;
        
        public Action<T> onAdd;
        public Action<List<T>,T> onAddWithOld;

        public Action<T> onRemove;
        public Action<List<T>,T> onRemoveWithOld;

        public Action onClear;
        public Action<List<T>> onClearWithOld;
        
        [Header("Value Persistence")]
        [SerializeField] bool resetOnSceneLoad = true;
        [SerializeField] bool resetOnExitPlaymode = true;
        
        [Header("References In Project")]
        [ReadOnly] [SerializeField] int total;
        [SerializeField] ReadWriteReferencesContainer gettersAndSetters = 
            new("list", typeof(ReferenceScriptableListVariableBase<T>), typeof(GetListVariable<T>), typeof(SetListVariable<T>));
        
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
        
        void CacheStartValueOnStart()
        {
            gettersAndSetters?.Clear();
            _startValue = new List<T>(list);
        }

        void ResetValueOnSceneLoad(Scene scene, Scene scene2)
        {
            if (!resetOnSceneLoad) return;
            list = new List<T>(_startValue);
        }
        
#if UNITY_EDITOR

        void Reset() => AssignDebugReferences();
        
        void ResetValueOnStoppedPlaying(PlayModeStateChange state)
        {
            if (!resetOnExitPlaymode) return;
            if (state == PlayModeStateChange.EnteredEditMode)
            {
                list = new List<T>(_startValue);
            }
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
