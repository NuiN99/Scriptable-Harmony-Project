using System;
using NuiN.ScriptableVariables.Core.ScriptableVariable.References.Base;

namespace NuiN.ScriptableVariables.Core.ScriptableVariable.References
{
    [Serializable]
    public class VariableReader<T> : ScriptableVariableReferenceBase<T>
    {
        public T Val => variable.value;
    }
}
