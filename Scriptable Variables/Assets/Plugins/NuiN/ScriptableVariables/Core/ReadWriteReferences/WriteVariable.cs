namespace NuiN.ScriptableVariables
{
    using System;
    using UnityEngine;

    [Serializable]
    public class WriteVariable<T>
    {
        [SerializeField] VariableSO<T> writeReference;
        public T Val {get => writeReference.value; set => writeReference.value = value; }
    }
}
