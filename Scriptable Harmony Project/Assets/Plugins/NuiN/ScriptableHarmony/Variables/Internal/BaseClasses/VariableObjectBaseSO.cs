using NuiN.ScriptableHarmony.Internal.Helpers;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NuiN.ScriptableHarmony.Base
{
    public abstract class VariableObjectBaseSO<T> : ScriptableObjectBaseSO<T>
    {
        [SerializeField] [TextArea] string description;
    
        new void OnEnable()
        {
            base.OnEnable();;
            GameLoadedEvent.OnGameLoaded += CacheStartValue;
            SceneManager.activeSceneChanged += ResetValueOnSceneLoad;
#if UNITY_EDITOR
            EditorApplication.playModeStateChanged += ResetValueOnStoppedPlaying;
#endif
        }
        new void OnDisable()
        {
            base.OnDisable();
            GameLoadedEvent.OnGameLoaded -= CacheStartValue;
            SceneManager.activeSceneChanged -= ResetValueOnSceneLoad;
#if  UNITY_EDITOR
            EditorApplication.playModeStateChanged -= ResetValueOnStoppedPlaying;
#endif
        }
    
        protected abstract void CacheStartValue();
        protected abstract void ResetValue();
        protected abstract bool ResetOnSceneLoad();
        protected abstract bool ResetOnExitPlayMode();
    
        void ResetValueOnSceneLoad(Scene s1, Scene s2)
        {
            if (ResetOnSceneLoad()) ResetValue();
        }
        
#if UNITY_EDITOR
        void ResetValueOnStoppedPlaying(PlayModeStateChange state)
        {
            if (ResetOnExitPlayMode() && state == PlayModeStateChange.EnteredEditMode) ResetValue();
        }
#endif
    }
}
