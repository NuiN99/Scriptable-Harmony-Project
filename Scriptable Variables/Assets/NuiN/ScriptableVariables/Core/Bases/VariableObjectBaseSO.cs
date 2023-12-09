using NuiN.ScriptableVariables.Internal.Helpers;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NuiN.ScriptableVariables.Base
{
    public abstract class VariableObjectBaseSO<T> : ScriptableObjectBaseSO<T>
    {
        [SerializeField] [TextArea] string description;
    
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
        protected abstract bool ResetOnSceneLoad();
        protected abstract bool ResetOnExitPlayMode();
    
        void ResetValueOnSceneLoad(Scene s1, Scene s2)
        {
            if (ResetOnSceneLoad()) ResetValue();
        }
        void ResetValueOnStoppedPlaying(PlayModeStateChange state)
        {
            if (ResetOnExitPlayMode() && state == PlayModeStateChange.EnteredEditMode) ResetValue();
        }
    }
}
