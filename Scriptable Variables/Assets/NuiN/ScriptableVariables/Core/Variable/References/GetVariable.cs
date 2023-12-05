using System;
using NuiN.ScriptableVariables.Variable.References.Base;

namespace NuiN.ScriptableVariables.References
{
    [Serializable]
    public class GetVariable<T> : ReferenceScriptableVariableBase<T>
    {
        public T Val => variable.value;
    }
}
