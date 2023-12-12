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

        public void SubOnAdd(Action<T> onAdd) => list.onAdd += onAdd;
        public void UnSubOnAdd(Action<T> onAdd) => list.onAdd -= onAdd;
        public void SubOnAddWithOld(Action<List<T>,T> onAddWithOld) => list.onAddWithOld += onAddWithOld;
        public void UnSubOnAddWithOld(Action<List<T>,T> onAddWithOld) => list.onAddWithOld -= onAddWithOld;
        
        public void SubOnAdd(Action<List<T>> onAddWithList) => list.onAddWithList += onAddWithList;
        public void UnSubOnAdd(Action<List<T>> onAddWithList) => list.onAddWithList -= onAddWithList;
        public void SubOnAddWithOld(Action<List<T>,List<T>> onAddWithListWithOld) => list.onAddWithListWithOld += onAddWithListWithOld;
        public void UnSubOnAddWithOld(Action<List<T>,List<T>> onAddWithListWithOld) => list.onAddWithListWithOld -= onAddWithListWithOld;
        
        public void SubOnRemove(Action<T> onRemove) => list.onRemove += onRemove;
        public void UnSubOnRemove(Action<T> onRemove) => list.onRemove -= onRemove;
        public void SubOnRemoveWithOld(Action<List<T>,T> onRemoveWithOld) => list.onRemoveWithOld += onRemoveWithOld;
        public void UnSubOnRemoveWithOld(Action<List<T>,T> onRemoveWithOld) => list.onRemoveWithOld -= onRemoveWithOld;
        
        public void SubOnRemove(Action<List<T>> onRemoveWithList) => list.onRemoveWithList += onRemoveWithList;
        public void UnSubOnRemove(Action<List<T>> onRemoveWithList) => list.onRemoveWithList -= onRemoveWithList;
        public void SubOnRemoveWithOld(Action<List<T>,List<T>> onRemoveWithListWithOld) => list.onRemoveWithListWithOld += onRemoveWithListWithOld;
        public void UnSubOnRemoveWithOld(Action<List<T>,List<T>> onRemoveWithListWithOld) => list.onRemoveWithListWithOld -= onRemoveWithListWithOld;
    }
}
