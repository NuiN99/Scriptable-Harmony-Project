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
        
        public void SubOnSet(Action<List<T>> onSet) => runtimeSet.onSet += onSet;
        public void UnSubOnSet(Action<List<T>> onSet) => runtimeSet.onSet -= onSet;
        public void SubOnSetWithOld(Action<List<T>, List<T>> onSetWithOld) => runtimeSet.onSetWithOld += onSetWithOld;
        public void UnSubOnSetWithOld(Action<List<T>, List<T>> onSetWithOld) => runtimeSet.onSetWithOld -= onSetWithOld;

        public void SubOnAdd(Action<T> onAdd) => runtimeSet.onAdd += onAdd;
        public void UnSubOnAdd(Action<T> onAdd) => runtimeSet.onAdd -= onAdd;
        public void SubOnAddWithOld(Action<List<T>,T> onAddWithOld) => runtimeSet.onAddWithOld += onAddWithOld;
        public void UnSubOnAddWithOld(Action<List<T>,T> onAddWithOld) => runtimeSet.onAddWithOld -= onAddWithOld;
        
        public void SubOnAdd(Action<List<T>> onAddWithList) => runtimeSet.onAddWithList += onAddWithList;
        public void UnSubOnAdd(Action<List<T>> onAddWithList) => runtimeSet.onAddWithList -= onAddWithList;
        public void SubOnAddWithOld(Action<List<T>,List<T>> onAddWithListWithOld) => runtimeSet.onAddWithListWithOld += onAddWithListWithOld;
        public void UnSubOnAddWithOld(Action<List<T>,List<T>> onAddWithListWithOld) => runtimeSet.onAddWithListWithOld -= onAddWithListWithOld;
        
        public void SubOnRemove(Action<T> onRemove) => runtimeSet.onRemove += onRemove;
        public void UnSubOnRemove(Action<T> onRemove) => runtimeSet.onRemove -= onRemove;
        public void SubOnRemoveWithOld(Action<List<T>,T> onRemoveWithOld) => runtimeSet.onRemoveWithOld += onRemoveWithOld;
        public void UnSubOnRemoveWithOld(Action<List<T>,T> onRemoveWithOld) => runtimeSet.onRemoveWithOld -= onRemoveWithOld;
        
        public void SubOnRemove(Action<List<T>> onRemoveWithList) => runtimeSet.onRemoveWithList += onRemoveWithList;
        public void UnSubOnRemove(Action<List<T>> onRemoveWithList) => runtimeSet.onRemoveWithList -= onRemoveWithList;
        public void SubOnRemoveWithOld(Action<List<T>,List<T>> onRemoveWithListWithOld) => runtimeSet.onRemoveWithListWithOld += onRemoveWithListWithOld;
        public void UnSubOnRemoveWithOld(Action<List<T>,List<T>> onRemoveWithListWithOld) => runtimeSet.onRemoveWithListWithOld -= onRemoveWithListWithOld;
        
        public void SubOnClear(Action onClear) => runtimeSet.onClear += onClear;
        public void UnSubOnClear(Action onClear) => runtimeSet.onClear -= onClear;
        public void SubOnClearWithOld(Action<List<T>> onClearWithOld) => runtimeSet.onClearWithOld += onClearWithOld;
        public void UnSubOnClearWithOld(Action<List<T>> onClearWithOld) => runtimeSet.onClearWithOld -= onClearWithOld;
    }
}