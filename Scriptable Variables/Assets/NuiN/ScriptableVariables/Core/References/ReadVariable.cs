using System;
using NuiN.ScriptableVariables.References.Base;

namespace NuiN.ScriptableVariables.References
{
    [Serializable]
    public class ReadVariable<T> : VariableReferenceParentClass<T>
    {
        public T Val => variable.value;
    }
}
