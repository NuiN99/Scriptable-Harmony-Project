using System;
using NuiN.ScriptableVariables.Base;
using UnityEngine;

namespace NuiN.ScriptableVariables.References.Base
{
    [Serializable]
    public class VariableReferenceParentClass<T>
    {
        public VariableSO<T> variable;
        
        public void AddOnChangeHandler(Action<T> onChange) => variable.onChange += onChange;
        public void RemoveOnChangeHandler(Action<T> onChange) => variable.onChange -= onChange;

        public void AddOnChangeHistoryHandler(Action<T, T> onChangeWithHistory) => variable.onChangeHistory += onChangeWithHistory; 
        public void RemoveOnChangeHistoryHandler(Action<T, T> onChangeWithHistory) => variable.onChangeHistory -= onChangeWithHistory; 
    }
}