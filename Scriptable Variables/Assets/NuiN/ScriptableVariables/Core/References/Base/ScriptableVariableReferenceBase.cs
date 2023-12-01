using System;
using System.Collections.Generic;
using System.Reflection;
using NuiN.ScriptableVariables.Core.Base;
using NuiN.ScriptableVariables.Tools;
using UnityEditor;
using UnityEngine;

namespace NuiN.ScriptableVariables.References.Base
{
    [Serializable]
    public class ScriptableVariableReferenceBase<T>
    {
        [SerializeField] protected ScriptableVariableBaseSO<T> variable;
        
        public void SubOnChange(Action<T> onChange) => variable.onChange += onChange;
        public void UnsubOnChange(Action<T> onChange) => variable.onChange -= onChange;

        public void SubOnChangeWithOld(Action<T, T> onChangeWithOld) => variable.onChangeWithOld += onChangeWithOld;
        public void UnsubOnChangeWithOld(Action<T, T> onChangeWithOld) => variable.onChangeWithOld -= onChangeWithOld;
    }
}
