using System;
using System.Collections.Generic;
using NuiN.ScriptableVariables.Core.Attributes;
using NuiN.ScriptableVariables.Core.RuntimeSet.Components.Base;
using NuiN.ScriptableVariables.Internal.Helpers;
using NuiN.ScriptableVariables.RuntimeSet.References;
using NuiN.ScriptableVariables.RuntimeSet.References.Base;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace NuiN.ScriptableVariables.Core.RuntimeSet.Base
{
    public class RuntimeSetBaseSO<T> : ScriptableObject where T : Object
    {
        [SerializeField] [TextArea] string description;
        
        [TypeMismatchFix]
        public List<T> runtimeSet = new();

        public Action<T> onAdd;
        public Action<List<T>, T> onAddWithOld;

        public Action<T> onRemove;
        public Action<List<T>, T> onRemoveWithOld;

        public Action onClear;
        public Action<List<T>> onClearWithOld;

#if UNITY_EDITOR
        [Header("References In Project")]
        [ReadOnly] [SerializeField] int total;
        
        [SerializeField] RuntimeSetReferencesContainer componentHolders = 
            new("runtimeSet", typeof(RuntimeSetItemComponentBase<T>), typeof(SetRuntimeSet<T>));
        
        [SerializeField] ReadWriteReferencesContainer gettersAndSetters = 
            new("runtimeSet", typeof(ReferenceRuntimeSetBase<T>), typeof(GetRuntimeSet<T>), typeof(SetRuntimeSet<T>));
#endif
        
        void OnEnable()
        {
            SceneManager.sceneUnloaded += ResetOnSceneUnloaded;
#if UNITY_EDITOR
            Selection.selectionChanged += OnSelectedInProjectWindow;
            EditorApplication.playModeStateChanged += ResetValueOnStoppedPlaying;
#endif
        }
        void OnDisable()
        {
            SceneManager.sceneUnloaded -= ResetOnSceneUnloaded;

#if UNITY_EDITOR
            EditorApplication.playModeStateChanged -= ResetValueOnStoppedPlaying;
            Selection.selectionChanged -= OnSelectedInProjectWindow;
#endif
        }
        
        void ResetOnSceneUnloaded(Scene scene) => runtimeSet.Clear();
        
#if UNITY_EDITOR
        
        void ResetValueOnStoppedPlaying(PlayModeStateChange state)
        {
            if (state != PlayModeStateChange.EnteredEditMode) return;
            runtimeSet.Clear();
        }

        void Reset() => AssignDebugReferences();
        
        void OnSelectedInProjectWindow()
        {
            gettersAndSetters?.Clear();
            componentHolders?.Clear();
            if (Selection.activeObject != this) return;
            AssignDebugReferences();
        }

        void AssignDebugReferences()
        {
            GameObject[] sceneObjs = FindObjectsByType<GameObject>(FindObjectsSortMode.None);

            gettersAndSetters.FindObjectsAndAssignReferences(this, sceneObjs, out int readWriteCount);
            componentHolders.FindObjectsAndAssignReferences(this, sceneObjs, out int setItemsCount);
            
            total = readWriteCount + setItemsCount;
        }
#endif
    }

}


