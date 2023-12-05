using System;
using System.Collections.ObjectModel;
using NuiN.ScriptableVariables.RuntimeSet.References.Base;
using Object = UnityEngine.Object;

namespace NuiN.ScriptableVariables.References
{
    [Serializable]
    public class GetRuntimeSet<T> : ReferenceRuntimeSetBase<T> where T : Object
    {
        public ReadOnlyCollection<T> Entities => runtimeSet.runtimeSet.AsReadOnly();
    }
}