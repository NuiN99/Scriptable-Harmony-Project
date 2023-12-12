using System;
using System.Threading.Tasks;
using NuiN.ScriptableHarmony.Base;
using NuiN.ScriptableHarmony.Editor.Attributes;
using NuiN.ScriptableHarmony.Internal.Helpers;
using NuiN.ScriptableHarmony.References;
using NuiN.ScriptableHarmony.Variable.References.Base;
using UnityEngine;

namespace NuiN.ScriptableHarmony.Variable.Base
{
    public class ScriptableVariableBaseSO<T> : ScriptableVariableLifetimeBaseSO<T>
    {
        T _prevValue;
        
        public T value;
        [SerializeField] [ReadOnlyPlayMode] T defaultValue;
        
        [Header("Value Persistence")]
        [SerializeField] bool resetOnSceneLoad;
        
        public Action<T> onChange;
        public Action<T, T> onChangeWithOld;
        
        [Header("Debugging")]
        [SerializeField] GetSetReferencesContainer gettersAndSetters = new("variable", typeof(ReferenceScriptableVariableBase<T>), typeof(GetVariable<T>), typeof(SetVariable<T>));
        protected override GetSetReferencesContainer GettersAndSetters { get => gettersAndSetters; set => gettersAndSetters = value; }

        [SOMethodButton("Save Value")]
        public void SaveValueButton()
        {
            defaultValue = value;
        }
        
        void OnValidate()
        {
            InvokeOnValueChangedInEditor();
        }
        async void InvokeOnValueChangedInEditor()
        {
            if (!Application.isPlaying || Equals(value, _prevValue)) return;
            
            // yield until next frame to avoid warnings when using sliders
            await Task.Yield();
            
            onChange?.Invoke(value);
            _prevValue = value;
        }
        
        protected override void CacheInitialValue() => defaultValue = value;
        protected override void ResetValue() => value = defaultValue;
        
        protected override bool ResetOnSceneLoad() => resetOnSceneLoad;
    }
}

