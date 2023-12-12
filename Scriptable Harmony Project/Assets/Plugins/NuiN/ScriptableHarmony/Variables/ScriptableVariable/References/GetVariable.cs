using System;
using NuiN.ScriptableHarmony.Variable.Base;
using NuiN.ScriptableHarmony.Variable.References.Base;

namespace NuiN.ScriptableHarmony.References
{
    [Serializable]
    public class GetVariable<T> : ReferenceScriptableVariableBase<T>
    {
        public T Val => variable.value;

        /// <summary> For invoking actions from a scriptable variable </summary>
        public GetVariable(ScriptableVariableBaseSO<T> variable) : base(variable) { }
    }
}
