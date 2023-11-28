using System;
using UnityEngine;
using NuiN.ScriptableVariables.Base;

namespace NuiN.ScriptableVariables
{
    [Serializable]
    public class ReadVariable<T>
    {
        [SerializeField] VariableSO<T> readReference;
        
        public T Val => readReference.value;

        public void AddOnChangeHandler(Action<T> onChange) => readReference.onChange += onChange;
        public void RemoveOnChangeHandler(Action<T> onChange) => readReference.onChange -= onChange;

        public void AddOnChangeHistoryHandler(Action<T, T> onChangeWithHistory) => readReference.onChangeHistory += onChangeWithHistory; 
        public void RemoveOnChangeHistoryHandler(Action<T, T> onChangeWithHistory) => readReference.onChangeHistory -= onChangeWithHistory; 
    }
}
