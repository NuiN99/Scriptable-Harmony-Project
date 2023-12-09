using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NuiN.ScriptableVariables.ListVariable.References.Base;
using NuiN.ScriptableVariables.Variable.References.Base;

namespace NuiN.ScriptableVariables.References
{
    [Serializable]
    public class GetListVariable<T> : ReferenceScriptableListVariableBase<T>
    {
        public ReadOnlyCollection<T> Items => list.list.AsReadOnly();
    }
}
