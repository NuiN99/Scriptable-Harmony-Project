using System;
using NuiN.ScriptableVariables.Variable.References.Base;

namespace NuiN.ScriptableVariables.Variable.References
{
    [Serializable]
    public class VariableReader<T> : ScriptableVariableReferenceBase<T>
    {
        public T Val => variable.value;
    }
}
