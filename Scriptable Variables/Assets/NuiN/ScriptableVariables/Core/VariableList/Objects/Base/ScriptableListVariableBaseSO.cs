using System;
using System.Collections.Generic;

namespace NuiN.ScriptableVariables.ListVariable.Base
{
    public class ScriptableListVariableBaseSO<T> : ScriptableVariableBaseBase<T>
    {
        List<T> _startValue = new();
        public List<T> list = new();
        
        public Action<List<T>> onSet;
        public Action<List<T>, List<T>> onSetWithOld;
        
        public Action<T> onAdd;
        public Action<List<T>,T> onAddWithOld;

        public Action<T> onRemove;
        public Action<List<T>,T> onRemoveWithOld;

        public Action onClear;
        public Action<List<T>> onClearWithOld;

        protected override void CacheStartValue()
        {
            _startValue = new List<T>(list);
        }

        protected override void ResetValue()
        {
            list = new List<T>(_startValue);
        }
    }
}
