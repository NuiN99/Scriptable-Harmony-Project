using System;
using System.Collections.Generic;
using NuiN.ScriptableHarmony.RuntimeSet.Base;
using UnityEngine;
using Object = UnityEngine.Object;

namespace NuiN.ScriptableHarmony.RuntimeSet.References.Base
{
    [Serializable]
    public class ReferenceRuntimeSetBase<T> where T : Object
    {
        [SerializeField] protected RuntimeSetBaseSO<T> runtimeSet;
        
        public void SubOnAdd(Action<T> onAdd) => runtimeSet.onAdd += onAdd;
        public void UnSubOnAdd(Action<T> onAdd) => runtimeSet.onAdd -= onAdd;

        public void SubOnAddWithOld(Action<List<T>,T> onAddWithOld) => runtimeSet.onAddWithOld += onAddWithOld;
        public void UnSubOnAddWithOld(Action<List<T>,T> onAddWithOld) => runtimeSet.onAddWithOld -= onAddWithOld;
        
        public void SubOnRemove(Action<T> onRemove) => runtimeSet.onRemove += onRemove;
        public void UnSubOnRemove(Action<T> onRemove) => runtimeSet.onRemove -= onRemove;

        public void SubOnRemoveWithOld(Action<List<T>,T> onRemoveWithOld) => runtimeSet.onRemoveWithOld += onRemoveWithOld;
        public void UnSubOnRemoveWithOld(Action<List<T>,T> onRemoveWithOld) => runtimeSet.onRemoveWithOld -= onRemoveWithOld;
        
        public void SubOnClear(Action onClear) => runtimeSet.onClear += onClear;
        public void UnSubOnClear(Action onClear) => runtimeSet.onClear -= onClear;

        public void SubOnClearWithOld(Action<List<T>> onClearWithOld) => runtimeSet.onClearWithOld += onClearWithOld;
        public void UnSubOnClearWithOld(Action<List<T>> onClearWithOld) => runtimeSet.onClearWithOld -= onClearWithOld;
    }
}