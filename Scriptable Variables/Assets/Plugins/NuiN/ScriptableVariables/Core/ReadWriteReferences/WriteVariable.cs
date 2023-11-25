namespace NuiN.ScriptableVariables
{
    using System;
    using UnityEngine;
    using NuiN.ScriptableVariables.Base;

    [Serializable]
    public class WriteVariable<T>
    {
        [SerializeField] VariableSO<T> writeReference;
        
        public T Val 
        {
            get => writeReference.value;
            set
            {
                writeReference.value = value;
                if (!writeReference.onChangeEvents) return;
                OnChange?.Invoke(writeReference.value);
            }
        }
        
        public Action<T> OnChange { get => writeReference.onChange; set => writeReference.onChange = value; }
    }
}
