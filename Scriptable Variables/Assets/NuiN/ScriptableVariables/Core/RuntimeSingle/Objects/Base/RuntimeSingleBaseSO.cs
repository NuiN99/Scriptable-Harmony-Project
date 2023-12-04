using System;
using NuiN.ScriptableVariables.Core.Attributes;
using NuiN.ScriptableVariables.Core.RuntimeSingle.Components.Base;
using NuiN.ScriptableVariables.Internal.Helpers;
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

        [TypeMismatchFix]
        public T runtimeSingle;

        public Action<T> onSet;
        public Action<T, T> onSetWithOld;
        
        public Action onRemove;
        public Action<T> onRemoveWithOld;
        
#if UNITY_EDITOR
        [Header("References In Project")]
        [ReadOnly] [SerializeField] int total;
        
        [SerializeField] RuntimeSetReferencesContainer componentHolders = 
            new("runtimeSingle", typeof(RuntimeSingleItemComponentBase<T>), typeof(SetRuntimeSingle<T>));
        
        [SerializeField] ReadWriteReferencesContainer gettersAndSetters = 
            new("runtimeSingle", typeof(ReferenceRuntimeSingleBase<T>), typeof(GetRuntimeSingle<T>), typeof(SetRuntimeSingle<T>));
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
        
        void ResetOnSceneUnloaded(Scene scene) => runtimeSingle = null;
        
#if UNITY_EDITOR
        
        void ResetValueOnStoppedPlaying(PlayModeStateChange state)
        {
            if (state != PlayModeStateChange.EnteredEditMode) return;
            runtimeSingle = null;
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


