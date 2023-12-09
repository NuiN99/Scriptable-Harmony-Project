using System.Collections;
using System.Collections.Generic;
using NuiN.ScriptableVariables.Internal.Attributes;
using NuiN.ScriptableVariables.Internal.Helpers;
using NuiN.ScriptableVariables.ListVariable.References.Base;
using NuiN.ScriptableVariables.References;
using NuiN.ScriptableVariables.RuntimeSet.Components.Base;
using UnityEditor;
using UnityEngine;

public abstract class SOBaseBaseBase<T> : ScriptableObject
{
    [Header("References In Project")]
    [ReadOnly] [SerializeField] int total;
    
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
