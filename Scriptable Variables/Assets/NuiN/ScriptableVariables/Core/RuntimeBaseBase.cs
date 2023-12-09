using System.Collections;
using System.Collections.Generic;
using NuiN.ScriptableVariables.Internal.Helpers;
using NuiN.ScriptableVariables.References;
using NuiN.ScriptableVariables.RuntimeSet.Components.Base;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class RuntimeBaseBase<T> : SOBaseBaseBase<T> where T : Object
{
    
    protected abstract RuntimeSetReferencesContainer ComponentHolders { get; set; }
    
    new void OnEnable()
    {
        base.OnEnable();
        SceneManager.sceneUnloaded += ResetOnSceneUnloaded;
#if UNITY_EDITOR
        EditorApplication.playModeStateChanged += ResetValueOnStoppedPlaying;
        Selection.selectionChanged += OnSelectedInProjectWindow;
#endif
    }
    new void OnDisable()
    {
        base.OnDisable();
        SceneManager.sceneUnloaded -= ResetOnSceneUnloaded;
#if UNITY_EDITOR
        EditorApplication.playModeStateChanged -= ResetValueOnStoppedPlaying;
        Selection.selectionChanged -= OnSelectedInProjectWindow;
#endif
    }
    
    void ResetValueOnStoppedPlaying(PlayModeStateChange state)
    {
        if (state != PlayModeStateChange.EnteredEditMode) return;
        ResetValue();
    }

    void OnSelectedInProjectWindow()
    {
        ComponentHolders?.Clear();
        if (Selection.activeObject != this) return;
        AssignDebugReferences();
    }
    
    void AssignDebugReferences()
    {
        GameObject[] sceneObjs = FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        ComponentHolders.FindObjectsAndAssignReferences(this, sceneObjs, out int setItemsCount);
    }
    
    void ResetOnSceneUnloaded(Scene scene) => ResetValue();
    protected abstract void ResetValue();
}
