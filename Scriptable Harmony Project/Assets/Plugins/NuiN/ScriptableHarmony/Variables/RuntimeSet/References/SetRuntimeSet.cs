using System;
using System.Collections.Generic;
using NuiN.ScriptableHarmony.RuntimeSet.References.Base;
using Object = UnityEngine.Object;

namespace NuiN.ScriptableHarmony.References
{
    [Serializable]
    public class SetRuntimeSet<T> : ReferenceRuntimeSetBase<T> where T : Object
    {
        public List<T> Entities => runtimeSet.entities;
    
        public void Add(T item)
        {
            if (item == null) return;
        
            var oldItems = new List<T>(Entities);
            Entities.Add(item);
            
            runtimeSet.onAddWithListWithOld?.Invoke(oldItems, Entities);
            runtimeSet.onAddWithOld?.Invoke(oldItems, item);
            runtimeSet.onAddWithList?.Invoke(Entities);
            runtimeSet.onAdd?.Invoke(item);
        }
        public void AddNoInvoke(T item)
        {
            if (item == null) return;
            Entities.Add(item);
        }
        
        public void Insert(T item, int index)
        {
            if (item == null) return;
            
            var oldItems = new List<T>(Entities);
            Entities.Insert(index, item);
            
            runtimeSet.onAddWithListWithOld?.Invoke(oldItems, Entities);
            runtimeSet.onAddWithOld?.Invoke(oldItems, item);
            runtimeSet.onAddWithList?.Invoke(Entities);
            runtimeSet.onAdd?.Invoke(item);
        }
        public void InsertNoInvoke(T item, int index)
        {
            if (item == null) return;
            Entities.Insert(index, item);
        }
    
        public void Remove(T item)
        {
            if(!Entities.Remove(item)) return;
            
            var oldItems = new List<T>(Entities);
            
            runtimeSet.onRemoveWithListWithOld?.Invoke(oldItems, Entities);
            runtimeSet.onRemoveWithOld?.Invoke(oldItems, item);
            runtimeSet.onRemoveWithList?.Invoke(Entities);
            runtimeSet.onRemove?.Invoke(item);
        }
        public void RemoveNoInvoke(T item)
        {
            Entities.Remove(item);
        }
        
        public void RemoveAt(int index)
        {
            T removedItem = Entities[index];
            if (removedItem == null) return;
            
            var oldItems = new List<T>(Entities);
            Entities.RemoveAt(index);
            
            runtimeSet.onRemoveWithListWithOld?.Invoke(oldItems, Entities);
            runtimeSet.onRemoveWithOld?.Invoke(oldItems, removedItem);
            runtimeSet.onRemoveWithList?.Invoke(Entities);
            runtimeSet.onRemove?.Invoke(removedItem);
        }
        public void RemoveAtNoInvoke(int index)
        {
            Entities.RemoveAt(index);
        }
        
        public void Replace(IEnumerable<T> newList)
        {
            var oldValue = new List<T>(Entities);
            runtimeSet.entities = new List<T>(newList);

            runtimeSet.onReplaceWithOld?.Invoke(oldValue, Entities);
            runtimeSet.onReplace?.Invoke(Entities);
        }
        public void ReplaceNoInvoke(IEnumerable<T> newList)
        {
            runtimeSet.entities = new List<T>(newList);
        }
        
        public void Clear()
        {
            var oldValue = new List<T>(Entities);
            Entities.Clear();

            runtimeSet.onClearWithOld?.Invoke(oldValue);
            runtimeSet.onClear?.Invoke();
        }
        public void ClearNoInvoke()
        {
            runtimeSet.entities.Clear();
        }
    }
}