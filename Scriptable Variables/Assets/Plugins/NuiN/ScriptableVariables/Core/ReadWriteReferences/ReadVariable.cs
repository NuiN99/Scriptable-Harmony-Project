namespace NuiN.ScriptableVariables
{
    using System;
    using UnityEngine;

    [Serializable]
    public class ReadVariable<T>
    {
        [SerializeField] VariableSO<T> readReference;
        public T Val => readReference.value;
    }
}
