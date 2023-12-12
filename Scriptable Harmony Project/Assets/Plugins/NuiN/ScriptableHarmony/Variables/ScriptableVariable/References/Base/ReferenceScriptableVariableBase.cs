using System;
using NuiN.ScriptableHarmony.Variable.Base;
using UnityEngine;

namespace NuiN.ScriptableHarmony.Variable.References.Base
{
    [Serializable]
    public class ReferenceScriptableVariableBase<T>
    {
        [SerializeField] protected ScriptableVariableBaseSO<T> variable;
        
        public ReferenceScriptableVariableBase(ScriptableVariableBaseSO<T> variable)
        {
            this.variable = variable;
        }
        
        public void SubOnChange(Action<T> onChange) => variable.onChange += onChange;
        public void UnSubOnChange(Action<T> onChange) => variable.onChange -= onChange;

        public void SubOnChangeWithOld(Action<T, T> onChangeWithOld) => variable.onChangeWithOld += onChangeWithOld;
        public void UnSubOnChangeWithOld(Action<T, T> onChangeWithOld) => variable.onChangeWithOld -= onChangeWithOld;
    }
}
