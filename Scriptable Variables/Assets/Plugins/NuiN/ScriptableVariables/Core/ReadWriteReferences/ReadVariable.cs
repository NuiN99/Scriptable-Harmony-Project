namespace NuiN.ScriptableVariables
{
    using System;
    using UnityEngine;
    using NuiN.ScriptableVariables.Base;

    [Serializable]
    public class ReadVariable<T>
    {
        [SerializeField] VariableSO<T> readReference;
        
        public T Val => readReference.value;
        
        public Action<T> OnChange
        {
            get => readReference.onChange;
            set => readReference.onChange = value;
        }
    }
}
