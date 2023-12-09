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
    protected int totalComponentHolders;
    protected abstract RuntimeSetReferencesContainer ComponentHolders { get; set; }
    
    new void OnEnable()
    {
        SceneManager.sceneUnloaded += ResetOnSceneUnloaded;
#if UNITY_EDITOR
        base.OnEnable();
        EditorApplication.playModeStateChanged += ResetValueOnStoppedPlaying;
        Selection.selectionChanged += OnSelectedInProjectWindow;
#endif
    }
    new void OnDisable()
    {
        SceneManager.sceneUnloaded -= ResetOnSceneUnloaded;
#if UNITY_EDITOR
        base.OnDisable();
        EditorApplication.playModeStateChanged -= ResetValueOnStoppedPlaying;
        Selection.selectionChanged -= OnSelectedInProjectWindow;
#endif
    }
    
    protected abstract void ResetValue();
    
    void ResetValueOnStoppedPlaying(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.EnteredEditMode) ResetValue();
    }
    
    void ResetOnSceneUnloaded(Scene scene) => ResetValue();

    void OnSelectedInProjectWindow()
    {
        ComponentHolders?.Clear();
        if (Selection.activeObject != this) return;
        AssignComponentDebugReferences();
    }
    
    void AssignComponentDebugReferences()
    {
        GameObject[] sceneObjs = FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        ComponentHolders.FindObjectsAndAssignReferences(this, sceneObjs, out totalComponentHolders);
    }
}
