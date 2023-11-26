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
        
        public Action<T> OnChange
        {
            get => readReference.onChange;
            set => readReference.onChange = value;
        }
    }
}
