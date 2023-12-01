using System;
using NuiN.ScriptableVariables.References.Base;
using UnityEditor;

namespace NuiN.ScriptableVariables.References
{
    [Serializable]
    public class VariableWriter<T> : ScriptableVariableReferenceBase<T>
    {
        public T Val => variable.value;

        public void Set(T value, bool invokeActions = true)
        {
            T oldValue = variable.value;
            variable.value = value;
            
            #if UNITY_EDITOR
            EditorUtility.SetDirty(variable);
            #endif

            if (!invokeActions) return;
            
            variable.onChangeWithOld?.Invoke(oldValue, value);
            variable.onChange?.Invoke(value);
        }
    }
}
