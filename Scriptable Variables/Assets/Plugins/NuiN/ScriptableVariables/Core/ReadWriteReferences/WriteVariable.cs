namespace NuiN.ScriptableVariables
{
    using System;
    using UnityEngine;
    using NuiN.ScriptableVariables.Base;
    using UnityEditor;

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
                if (!writeReference.invokeOnChangeEvent) return;
                OnChange?.Invoke(writeReference.value);
                
                #if UNITY_EDITOR
                // so that changes made through code are shown in version control
                EditorUtility.SetDirty(writeReference);
                #endif
            }
        }

        public Action<T> OnChange
        {
            get => writeReference.onChange; 
            set => writeReference.onChange = value;
        }
    }
}
