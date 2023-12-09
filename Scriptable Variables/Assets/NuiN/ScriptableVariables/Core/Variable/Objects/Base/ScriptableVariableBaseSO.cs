using System;
using NuiN.ScriptableVariables.Internal.Helpers;
using NuiN.ScriptableVariables.References;
using NuiN.ScriptableVariables.RuntimeSingle.References.Base;
using NuiN.ScriptableVariables.Variable.References.Base;
using UnityEngine;

namespace NuiN.ScriptableVariables.Variable.Base
{
    public class ScriptableVariableBaseSO<T> : ScriptableVariableBaseBase<T>
    {
        T _startValue;
        public T value;

        public Action<T> onChange;
        public Action<T, T> onChangeWithOld;
        
        protected override void CacheStartValue()
        {
            _startValue = value;
        }

        protected override void ResetValue()
        {
            value = _startValue;
        }

        [SerializeField] ReadWriteReferencesContainer gettersAndSetters = 
            new("variable", typeof(ReferenceScriptableVariableBase<T>), typeof(GetVariable<T>), typeof(SetVariable<T>));

        protected override ReadWriteReferencesContainer GettersAndSetters
        {
            get => gettersAndSetters; 
            set => gettersAndSetters = value;
        }
    }
}
