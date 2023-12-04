using System;
using NuiN.ScriptableVariables.Variable.Base;
using UnityEngine;

namespace NuiN.ScriptableVariables.Variable.References.Base
{
    [Serializable]
    public class ReferenceScriptableVariableBase<T>
    {
        [SerializeField] protected ScriptableVariableBaseSO<T> variable;
        
        public void SubOnChange(Action<T> onChange) => variable.onChange += onChange;
        public void UnsubOnChange(Action<T> onChange) => variable.onChange -= onChange;

        public void SubOnChangeWithOld(Action<T, T> onChangeWithOld) => variable.onChangeWithOld += onChangeWithOld;
        public void UnsubOnChangeWithOld(Action<T, T> onChangeWithOld) => variable.onChangeWithOld -= onChangeWithOld;
    }
}
