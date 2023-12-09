using System;
using NuiN.ScriptableHarmony.Variable.Base;
using UnityEngine;

namespace NuiN.ScriptableHarmony.Variable.References.Base
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
