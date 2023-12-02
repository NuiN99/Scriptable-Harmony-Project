using System;
using System.Collections.Generic;
using NuiN.ScriptableVariables.Core.Editor;
using NuiN.ScriptableVariables.Core.Helpers;
using NuiN.ScriptableVariables.Core.RuntimeSet.Components.Base;
using NuiN.ScriptableVariables.Core.RuntimeSet.References;
using NuiN.ScriptableVariables.Core.RuntimeSet.References.Base;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace NuiN.ScriptableVariables.Core.RuntimeSet.ScriptableObjectClasses.Base
{
    public class RuntimeSetBaseSO<T> : ScriptableObject where T : Object
    {
        [SerializeField] [TextArea] string description;
        
        public List<T> runtimeSet = new();

        public Action<T> onAdd;
        public Action<List<T>, T> onAddWithOld;

        public Action<T> onRemove;
        public Action<List<T>, T> onRemoveWithOld;

        public Action onClear;
        public Action<List<T>> onClearWithOld;

        bool _loadedFirstScene;
        
        [SerializeField, Header("Value Persistence")] bool resetOnSceneLoad = true;
        
#if UNITY_EDITOR
        [Header("References In Project")]
        [ReadOnly] [SerializeField] int total;
        
        [SerializeField] RuntimeSetReferencesContainer setItems = 
            new("runtimeSet", typeof(RuntimeSetItemComponentBase<T>), typeof(RuntimeSetWriter<T>));
        
        [SerializeField] ReadWriteReferencesContainer readersAndWriters = 
            new("runtimeSet", typeof(RuntimeSetReferenceBase<T>), typeof(RuntimeSetReader<T>), typeof(RuntimeSetWriter<T>));
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
            runtimeSet.Clear();
        }
        
#if UNITY_EDITOR
        
        void ResetValueOnStoppedPlaying(PlayModeStateChange state)
        {
            if (state != PlayModeStateChange.EnteredEditMode) return;
                
            runtimeSet.Clear();
            _loadedFirstScene = false;
        }

        void Reset() => AssignDebugReferences();
        
        void OnSelectedInProjectWindow()
        {
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


