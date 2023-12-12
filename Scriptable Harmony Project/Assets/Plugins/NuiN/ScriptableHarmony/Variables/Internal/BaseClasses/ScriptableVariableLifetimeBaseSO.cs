using NuiN.ScriptableHarmony.Events;
using NuiN.ScriptableHarmony.Internal.Helpers;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NuiN.ScriptableHarmony.Base
{
    public abstract class ScriptableVariableLifetimeBaseSO<T> : ScriptableObjectBaseSO<T>
    {
        [SerializeField] [TextArea] string description;
    
        protected new virtual void OnEnable()
        {
            base.OnEnable();;
            GameLoadedEvent.OnGameLoaded += CacheInitialValue;
            SceneManager.activeSceneChanged += ResetValueOnSceneLoad;
            VariableEvents.OnResetAllVariableObjects += ResetValue;
#if UNITY_EDITOR
            EditorApplication.playModeStateChanged += ResetValueOnStoppedPlaying;
#endif
        }
        new void OnDisable()
        {
            base.OnDisable();
            GameLoadedEvent.OnGameLoaded -= CacheInitialValue;
            SceneManager.activeSceneChanged -= ResetValueOnSceneLoad;
            VariableEvents.OnResetAllVariableObjects -= ResetValue;
#if  UNITY_EDITOR
            EditorApplication.playModeStateChanged -= ResetValueOnStoppedPlaying;
#endif
        }
    
        protected abstract void CacheInitialValue();
        protected abstract void ResetValue();
        protected abstract bool ResetOnSceneLoad();
    
        void ResetValueOnSceneLoad(Scene s1, Scene s2)
        {
            if (ResetOnSceneLoad()) ResetValue();
        }
        
#if UNITY_EDITOR
        void ResetValueOnStoppedPlaying(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.EnteredEditMode) ResetValue();
        }
#endif
    }
}
