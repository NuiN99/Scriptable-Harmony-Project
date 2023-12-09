using System;

namespace NuiN.ScriptableVariables.Variable.Base
{
    public class ScriptableVariableBaseSO<T> : ScriptableVariableBaseBase<T>
    {
        T _startValue;
        public T value;

        public Action<T> onChange;
        public Action<T, T> onChangeWithOld;
        
        protected override void CacheStartValue()
        {
            _startValue = value;
        }

        protected override void ResetValue()
        {
            value = _startValue;
        }
    }
}
