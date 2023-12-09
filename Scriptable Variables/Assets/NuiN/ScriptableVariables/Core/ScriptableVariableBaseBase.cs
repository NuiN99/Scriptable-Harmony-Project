using NuiN.ScriptableVariables.Internal.Attributes;
using NuiN.ScriptableVariables.Internal.Helpers;
using NuiN.ScriptableVariables.ListVariable.References.Base;
using NuiN.ScriptableVariables.References;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class ScriptableVariableBaseBase<T> : SOBaseBaseBase<T>
{
    [SerializeField] [TextArea] string description;
    
    [Header("Value Persistence")]
    [SerializeField] bool resetOnSceneLoad = true;
    [SerializeField] bool resetOnExitPlaymode = true;
    
    new void OnEnable()
    {
        base.OnEnable();;
        GameLoadedEvent.OnGameLoaded += CacheStartValue;
        SceneManager.activeSceneChanged += ResetValueOnSceneLoad;
        EditorApplication.playModeStateChanged += ResetValueOnStoppedPlaying;
    }
    new void OnDisable()
    {
        base.OnDisable();
        GameLoadedEvent.OnGameLoaded -= CacheStartValue;
        SceneManager.activeSceneChanged -= ResetValueOnSceneLoad;
        EditorApplication.playModeStateChanged -= ResetValueOnStoppedPlaying;
    }
    
    protected abstract void CacheStartValue();
    protected abstract void ResetValue();
    
    void ResetValueOnSceneLoad(Scene s1, Scene s2)
    {
        if (resetOnSceneLoad) ResetValue();
    }
    
    void ResetValueOnStoppedPlaying(PlayModeStateChange state)
    {
        if (!resetOnExitPlaymode) return;
        if (state == PlayModeStateChange.EnteredEditMode) ResetValue();
    }
}
