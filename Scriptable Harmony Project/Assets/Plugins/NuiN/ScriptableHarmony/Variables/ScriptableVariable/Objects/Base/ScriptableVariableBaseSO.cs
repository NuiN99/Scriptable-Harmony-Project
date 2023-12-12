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
        T _initialValue;
        T _prevValue;

        public T value;
        
        [Header("Value Persistence")]
        [SerializeField] bool resetOnSceneLoad = true;
        
        public Action<T> onChange;
        public Action<T, T> onChangeWithOld;
        
        [Header("Debug References")]
        [SerializeField] ReadWriteReferencesContainer gettersAndSetters = new("variable", typeof(ReferenceScriptableVariableBase<T>), typeof(GetVariable<T>), typeof(SetVariable<T>));
        protected override ReadWriteReferencesContainer GettersAndSetters { get => gettersAndSetters; set => gettersAndSetters = value; }

        [SOMethodButton("Save Value")]
        public void SaveValueButton()
        {
            _initialValue = value;
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
        
        protected override void CacheInitialValue() => _initialValue = value;
        protected override void ResetValue() => value = _initialValue;
        
        protected override bool ResetOnSceneLoad() => resetOnSceneLoad;
    }
}

