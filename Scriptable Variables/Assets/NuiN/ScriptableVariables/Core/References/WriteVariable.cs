using System;
using UnityEngine;
using NuiN.ScriptableVariables.Base;
using UnityEditor;

namespace NuiN.ScriptableVariables
{
    [Serializable]
    public class WriteVariable<T>
    {
        [SerializeField] VariableSO<T> writeReference;
        
        public T Val 
        {
            get => writeReference.value;
            set
            {
                if (writeReference.onChangeHistoryEvent) writeReference.onChangeHistory?.Invoke(writeReference.value, value);
                writeReference.value = value;
                if (writeReference.onChangeEvent) writeReference.onChange?.Invoke(writeReference.value);
                
                #if UNITY_EDITOR
                // so that changes made through code are shown in version control
                EditorUtility.SetDirty(writeReference);
                #endif
            }
        }
        
        public void AddOnChangeHandler(Action<T> onChange) => writeReference.onChange += onChange;
        public void RemoveOnChangeHandler(Action<T> onChange) => writeReference.onChange -= onChange;

        public void AddOnChangeHistoryHandler(Action<T, T> onChangeWithHistory) => writeReference.onChangeHistory += onChangeWithHistory; 
        public void RemoveOnChangeHistoryHandler(Action<T, T> onChangeWithHistory) => writeReference.onChangeHistory -= onChangeWithHistory; 
    }
}
