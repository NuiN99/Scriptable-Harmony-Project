using System;
using System.Collections.ObjectModel;
using NuiN.ScriptableVariables.Core.RuntimeSet.References.Base;
using Object = UnityEngine.Object;

namespace NuiN.ScriptableVariables.Core.RuntimeSet.References
{
    [Serializable]
    public class RuntimeSingleReader<T> : RuntimeSetReferenceBase<T> where T : Object
    {
        public ReadOnlyCollection<T> Items => runtimeSet.runtimeSet.AsReadOnly();
    }
}