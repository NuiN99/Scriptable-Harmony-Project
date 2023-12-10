using System;
using System.Collections.Generic;
using NuiN.ScriptableHarmony.ListVariable.Base;
using UnityEngine;

namespace NuiN.ScriptableHarmony.ListVariable.References.Base
{
    [Serializable]
    public class ReferenceScriptableListVariableBase<T>
    {
        [SerializeField] protected ScriptableListVariableBaseSO<T> list;
        
        public void SubOnSet(Action<List<T>> onSet) => list.onSet += onSet;
        public void UnSubOnSet(Action<List<T>> onSet) => list.onSet -= onSet;

        public void SubOnSetWithOld(Action<List<T>, List<T>> onSetWithOld) => list.onSetWithOld += onSetWithOld;
        public void UnSubOnSetWithOld(Action<List<T>, List<T>> onSetWithOld) => list.onSetWithOld -= onSetWithOld;

        public void SubOnAdd(Action<T> onAdd) => list.onAdd += onAdd;
        public void UnSubOnAdd(Action<T> onAdd) => list.onAdd -= onAdd;
        
        public void SubOnAddWithOld(Action<List<T>,T> onAddWithOld) => list.onAddWithOld += onAddWithOld;
        public void UnSubOnAddWithOld(Action<List<T>,T> onAddWithOld) => list.onAddWithOld -= onAddWithOld;
        
        public void SubOnRemove(Action<T> onRemove) => list.onRemove += onRemove;
        public void UnSubOnRemove(Action<T> onRemove) => list.onRemove -= onRemove;
        
        public void SubOnRemoveWithOld(Action<List<T>,T> onRemoveWithOld) => list.onRemoveWithOld += onRemoveWithOld;
        public void UnSubOnRemoveWithOld(Action<List<T>,T> onRemoveWithOld) => list.onRemoveWithOld -= onRemoveWithOld;
        
        public void SubOnClear(Action onClear) => list.onClear += onClear;
        public void UnSubOnClear(Action onClear) => list.onClear -= onClear;
        
        public void SubOnClearWithOld(Action<List<T>> onClearWithOld) => list.onClearWithOld += onClearWithOld;
        public void UnSubOnClearWithOld(Action<List<T>> onClearWithOld) => list.onClearWithOld -= onClearWithOld;
    }
}
