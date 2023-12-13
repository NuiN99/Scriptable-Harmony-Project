using System;
using System.Diagnostics;
using NuiN.ScriptableHarmony.Internal.Logging;
using NuiN.ScriptableHarmony.Variable.References.Base;
using UnityEditor;

namespace NuiN.ScriptableHarmony.References
{
    [Serializable]
    public class SetVariable<T> : ReferenceScriptableVariableBase<T>
    {
        public T Val => variable.value;
        public T DefaultVal => variable.DefaultValue;

        public void Set(T value)
        {
            T oldValue = variable.value;
            variable.value = value;
            
            SetDirty();

            variable.onChangeWithOld?.Invoke(oldValue, value);
            variable.onChange?.Invoke(value);
            
            SHLogger.LogSetEvent("Set Variable", oldValue, Val, variable);
        }
        public void SetNoInvoke(T value)
        {
            variable.value = value;

            SetDirty();
        }

        public void ResetValue()
        {
            Set(variable.DefaultValue);
        }
        public void ResetValueNoInvoke()
        {
            SetNoInvoke(variable.DefaultValue);
        }

        [Conditional("UNITY_EDITOR")]
        void SetDirty()
        {
            EditorUtility.SetDirty(variable);
        }
    }
}
