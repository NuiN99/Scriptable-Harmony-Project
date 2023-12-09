using NuiN.ScriptableVariables.Internal.Attributes;
using NuiN.ScriptableVariables.Internal.Helpers;
using NuiN.ScriptableVariables.ListVariable.References.Base;
using NuiN.ScriptableVariables.References;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class ScriptableVariableBaseBase<T> : ScriptableObject
{
    [SerializeField] [TextArea] string description;
    
    [Header("Value Persistence")]
    [SerializeField] bool resetOnSceneLoad = true;
    [SerializeField] bool resetOnExitPlaymode = true;
        
    [Header("References In Project")]
    [ReadOnly] [SerializeField] int total;
    [SerializeField] ReadWriteReferencesContainer gettersAndSetters = 
        new("list", typeof(ReferenceScriptableListVariableBase<T>), typeof(GetListVariable<T>), typeof(SetListVariable<T>));
    
    void OnEnable()
    {
        GameLoadedEvent.OnGameLoaded += CacheStartValueBase;
        SceneManager.activeSceneChanged += ResetValueOnSceneLoad;
#if UNITY_EDITOR
        EditorApplication.playModeStateChanged += ResetValueOnStoppedPlaying;
        Selection.selectionChanged += OnSelectedInProjectWindow;
#endif
    }
    void OnDisable()
    {
        GameLoadedEvent.OnGameLoaded -= CacheStartValueBase;
        SceneManager.activeSceneChanged -= ResetValueOnSceneLoad;
#if UNITY_EDITOR
        EditorApplication.playModeStateChanged -= ResetValueOnStoppedPlaying;
        Selection.selectionChanged -= OnSelectedInProjectWindow;
#endif
    }
    
    void Reset() => AssignDebugReferences();
    
    protected abstract void CacheStartValue();
    protected abstract void ResetValue();

    void CacheStartValueBase()
    {
        gettersAndSetters?.Clear();
        CacheStartValue();
    }
    void ResetValueOnSceneLoad(Scene s1, Scene s2)
    {
        if (resetOnSceneLoad) ResetValue();
    }
    
    void ResetValueOnStoppedPlaying(PlayModeStateChange state)
    {
        if (!resetOnExitPlaymode) return;
        if (state == PlayModeStateChange.EnteredEditMode) ResetValue();
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
}
