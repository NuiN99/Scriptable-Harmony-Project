using System;
using NuiN.ScriptableVariables.Base;
using NuiN.ScriptableVariables.Internal.Helpers;
using NuiN.ScriptableVariables.References;
using NuiN.ScriptableVariables.Variable.References.Base;
using UnityEngine;

namespace NuiN.ScriptableVariables.Variable.Base
{
    public class ScriptableVariableBaseSO<T> : VariableObjectBaseSO<T>
    {
        T _startValue;
        public T value;
        
        [Header("Value Persistence")]
        [SerializeField] bool resetOnSceneLoad = true;
        [SerializeField] bool resetOnExitPlaymode = true;

        public Action<T> onChange;
        public Action<T, T> onChangeWithOld;
        
        [Header("Debug References")]
        [SerializeField] ReadWriteReferencesContainer gettersAndSetters = new("variable", typeof(ReferenceScriptableVariableBase<T>), typeof(GetVariable<T>), typeof(SetVariable<T>));
        protected override ReadWriteReferencesContainer GettersAndSetters { get => gettersAndSetters; set => gettersAndSetters = value; }
        protected override void CacheStartValue() => _startValue = value;
        protected override void ResetValue() => value = _startValue;
        
        protected override bool ResetOnSceneLoad() => resetOnSceneLoad;
        protected override bool ResetOnExitPlayMode() => resetOnExitPlaymode;
    }
}

