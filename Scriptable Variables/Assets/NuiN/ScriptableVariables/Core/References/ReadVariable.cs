using System;
using NuiN.ScriptableVariables.References.Base;

namespace NuiN.ScriptableVariables.References
{
    [Serializable]
    public class ReadVariable<T> : ScriptableVariableReferenceBase<T>
    {
        public T Val => variable.value;
    }
}
