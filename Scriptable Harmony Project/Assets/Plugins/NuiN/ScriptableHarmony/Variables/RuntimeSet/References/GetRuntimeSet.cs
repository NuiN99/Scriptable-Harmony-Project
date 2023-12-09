using System;
using System.Collections.ObjectModel;
using NuiN.ScriptableHarmony.RuntimeSet.References.Base;
using Object = UnityEngine.Object;

namespace NuiN.ScriptableHarmony.References
{
    [Serializable]
    public class GetRuntimeSet<T> : ReferenceRuntimeSetBase<T> where T : Object
    {
        public ReadOnlyCollection<T> Entities => runtimeSet.runtimeSet.AsReadOnly();
    }
}