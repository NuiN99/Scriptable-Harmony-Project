using System;
using NuiN.ScriptableHarmony.RuntimeSingle.References.Base;
using Object = UnityEngine.Object;

namespace NuiN.ScriptableHarmony.References
{
    [Serializable]
    public class GetRuntimeSingle<T> : ReferenceRuntimeSingleBase<T> where T : Object
    {
        public T Entity => runtimeSingle.runtimeSingle;
    }
}