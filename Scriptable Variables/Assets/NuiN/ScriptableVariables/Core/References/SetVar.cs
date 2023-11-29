using System;
using NuiN.ScriptableVariables.References.Base;
using UnityEditor;

namespace NuiN.ScriptableVariables.References
{
    [Serializable]
    public class SetVar<T> : ScriptableVariableReferenceBase<T>
    {
        public T Val 
        {
            get => variable.value;
            set
            {
                if (variable.OnChangeWithOld) variable.onChangeWithOld?.Invoke(variable.value, value);
                variable.value = value;
                if (variable.OnChange) variable.onChange?.Invoke(variable.value);
                
                #if UNITY_EDITOR
                // so that changes made through code are shown in version control
                EditorUtility.SetDirty(variable);
                #endif
            }
        }
    }
}