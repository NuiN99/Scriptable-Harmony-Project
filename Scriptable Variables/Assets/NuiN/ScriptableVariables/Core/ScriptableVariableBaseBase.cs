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

    protected abstract bool ResetOnSceneLoad();
    protected abstract bool ResetOnExitPlayMode();

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
        if (ResetOnSceneLoad()) ResetValue();
    }
    
    void ResetValueOnStoppedPlaying(PlayModeStateChange state)
    {
        if (!ResetOnExitPlayMode()) return;
        if (state == PlayModeStateChange.EnteredEditMode) ResetValue();
    }
}
