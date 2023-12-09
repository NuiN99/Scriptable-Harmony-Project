using NuiN.ScriptableHarmony.Internal.Helpers;
using UnityEditor;
using UnityEngine;

namespace NuiN.ScriptableHarmony.Base
{
    public abstract class ScriptableObjectBaseSO<T> : ScriptableObject
    {
        protected int total;
        protected abstract ReadWriteReferencesContainer GettersAndSetters { get; set; }

        protected virtual void OnEnable()
        {
#if UNITY_EDITOR
            Selection.selectionChanged += OnSelectedInProjectWindow;
#endif
        }
        protected virtual void OnDisable()
        {
#if UNITY_EDITOR
            Selection.selectionChanged -= OnSelectedInProjectWindow;
#endif
        }
    
        void Reset() => AssignDebugReferences();
        
        void OnSelectedInProjectWindow()
        {
            GettersAndSetters?.Clear();
            if (Selection.activeObject != this) return;
            AssignDebugReferences();
        }
    
        void AssignDebugReferences()
        {
            GameObject[] sceneObjs = FindObjectsByType<GameObject>(FindObjectsSortMode.None);
            GettersAndSetters.FindObjectsAndAssignReferences(this, sceneObjs, out total);
        }
    }
}
