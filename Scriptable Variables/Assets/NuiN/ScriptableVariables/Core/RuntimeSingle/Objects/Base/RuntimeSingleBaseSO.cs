using System;
using NuiN.ScriptableVariables.Core.Attributes;
using NuiN.ScriptableVariables.Core.InternalHelpers;
using NuiN.ScriptableVariables.Core.RuntimeSingle.Components.Base;
using NuiN.ScriptableVariables.RuntimeSingle.References;
using NuiN.ScriptableVariables.RuntimeSingle.References.Base;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace NuiN.ScriptableVariables.Core.RuntimeSingle.Base
{
    public class RuntimeSingleBaseSO<T> : ScriptableObject where T : Object
    {
        [SerializeField] [TextArea] string description;

        public T item;

        public Action<T> onSet;
        public Action<T, T> onSetWithOld;
        
        public Action onRemove;
        public Action<T> onRemoveWithOld;
        
        bool _loadedFirstScene;
        
        [Header("Value Persistence")]
        [SerializeField] bool resetOnSceneLoad = true;
        
#if UNITY_EDITOR
        [Header("References In Project")]
        [ReadOnly] [SerializeField] int total;
        
        [SerializeField] RuntimeSetReferencesContainer setItems = 
            new("item", typeof(RuntimeSingleItemComponentBase<T>), typeof(SetRuntimeSingle<T>));
        
        [SerializeField] ReadWriteReferencesContainer readersAndWriters = 
            new("item", typeof(ReferenceRuntimeSingleBase<T>), typeof(GetRuntimeSingle<T>), typeof(SetRuntimeSingle<T>));
#endif
        
        void OnEnable()
        {
            SceneManager.activeSceneChanged += ResetValueOnSceneLoad;
#if UNITY_EDITOR
            Selection.selectionChanged += OnSelectedInProjectWindow;
            EditorApplication.playModeStateChanged += ResetValueOnStoppedPlaying;
#endif
        }
        void OnDisable()
        {
            SceneManager.activeSceneChanged -= ResetValueOnSceneLoad;
#if UNITY_EDITOR
            EditorApplication.playModeStateChanged -= ResetValueOnStoppedPlaying;
            Selection.selectionChanged -= OnSelectedInProjectWindow;
#endif
        }
        
        void ResetValueOnSceneLoad(Scene scene, Scene scene2)
        {
            if (!_loadedFirstScene)
            {
                _loadedFirstScene = true;
                return;
            }
            
            if (!resetOnSceneLoad) return;
            item = null;
        }
        
#if UNITY_EDITOR
        
        void ResetValueOnStoppedPlaying(PlayModeStateChange state)
        {
            if (state != PlayModeStateChange.EnteredEditMode) return;
                
            item = null;
            _loadedFirstScene = false;
        }

        void Reset() => AssignDebugReferences();
        
        void OnSelectedInProjectWindow()
        {
            readersAndWriters?.Clear();
            setItems?.Clear();
            if (Selection.activeObject != this) return;
            AssignDebugReferences();
        }

        void AssignDebugReferences()
        {
            GameObject[] sceneObjs = FindObjectsByType<GameObject>(FindObjectsSortMode.None);

            readersAndWriters.FindObjectsAndAssignReferences(this, sceneObjs, out int readWriteCount);
            setItems.FindObjectsAndAssignReferences(this, sceneObjs, out int setItemsCount);
            
            total = readWriteCount + setItemsCount;
        }
#endif
    }

}


