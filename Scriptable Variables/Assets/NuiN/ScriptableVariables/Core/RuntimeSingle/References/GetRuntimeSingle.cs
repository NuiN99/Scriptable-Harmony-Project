using System;
using System.Collections.ObjectModel;
using NuiN.ScriptableVariables.RuntimeSingle.References.Base;
using Object = UnityEngine.Object;

namespace NuiN.ScriptableVariables.RuntimeSingle.References
{
    [Serializable]
    public class GetRuntimeSingle<T> : ReferenceRuntimeSingleBase<T> where T : Object
    {
        public T Entity => runtimeSingle.runtimeSingle;
    }
}