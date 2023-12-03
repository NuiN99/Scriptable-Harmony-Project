using System;
using System.Collections.ObjectModel;
using NuiN.ScriptableVariables.RuntimeSet.References.Base;
using Object = UnityEngine.Object;

namespace NuiN.ScriptableVariables.RuntimeSingle.References
{
    [Serializable]
    public class GetRuntimeSingle<T> : ReferenceRuntimeSetBase<T> where T : Object
    {
        public ReadOnlyCollection<T> Items => runtimeSet.runtimeSet.AsReadOnly();
    }
}