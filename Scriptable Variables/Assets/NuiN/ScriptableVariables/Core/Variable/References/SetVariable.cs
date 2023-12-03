using System;
using NuiN.ScriptableVariables.Variable.References.Base;
using UnityEditor;

namespace NuiN.ScriptableVariables.Variable.References
{
    [Serializable]
    public class SetVariable<T> : ReferenceScriptableVariableBase<T>
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