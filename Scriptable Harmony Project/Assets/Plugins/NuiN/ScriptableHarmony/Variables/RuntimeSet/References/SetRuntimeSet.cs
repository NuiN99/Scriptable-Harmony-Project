using System;
using System.Collections.Generic;
using NuiN.ScriptableHarmony.RuntimeSet.References.Base;
using Object = UnityEngine.Object;

namespace NuiN.ScriptableHarmony.References
{
    [Serializable]
    public class SetRuntimeSet<T> : ReferenceRuntimeSetBase<T> where T : Object
    {
        public List<T> Entities => runtimeSet.runtimeSet;
    
        public void Add(T item, bool invokeActions = true, bool returnIfContains = true)
        {
            if (item == null) return;
            if (returnIfContains && Entities.Contains(item)) return;
        
            List<T> oldItems = Entities;
            Entities.Add(item);

            if (!invokeActions) return;
        
            runtimeSet.onAddWithListWithOld?.Invoke(oldItems, Entities);
            runtimeSet.onAddWithOld?.Invoke(oldItems, item);
            runtimeSet.onAddWithList?.Invoke(Entities);
            runtimeSet.onAdd?.Invoke(item);
        }
        
        public void Insert(T item, int index, bool invokeActions = true, bool returnIfContains = true)
        {
            if (item == null) return;
            if (returnIfContains && Entities.Contains(item)) return;
            
            List<T> oldItems = Entities;
            Entities.Insert(index, item);
            
            if (!invokeActions) return;
            
            runtimeSet.onAddWithListWithOld?.Invoke(oldItems, Entities);
            runtimeSet.onAddWithOld?.Invoke(oldItems, item);
            runtimeSet.onAddWithList?.Invoke(Entities);
            runtimeSet.onAdd?.Invoke(item);
        }
    
        public void Remove(T item, bool invokeActions = true, bool returnIfDoesntContain = true)
        {
            if (returnIfDoesntContain && !Entities.Contains(item)) return;
        
            List<T> oldItems = Entities;
            Entities.Remove(item);
        
            if (!invokeActions) return;
        
            runtimeSet.onRemoveWithListWithOld?.Invoke(oldItems, Entities);
            runtimeSet.onRemoveWithOld?.Invoke(oldItems, item);
            runtimeSet.onRemoveWithList?.Invoke(Entities);
            runtimeSet.onRemove?.Invoke(item);
        }
        
        public void RemoveAt(int index, bool invokeActions = true)
        {
            T removedItem = Entities[index];
            List<T> oldItems = Entities;
            Entities.RemoveAt(index);

            if (!invokeActions) return;
            
            runtimeSet.onRemoveWithListWithOld?.Invoke(oldItems, Entities);
            runtimeSet.onRemoveWithOld?.Invoke(oldItems, removedItem);
            runtimeSet.onRemoveWithList?.Invoke(Entities);
            runtimeSet.onRemove?.Invoke(removedItem);
        }

        public void Clear(bool invokeActions = true)
        {
            List<T> oldItems = Entities;
            Entities.Clear();

            if (!invokeActions) return;
            
            runtimeSet.onClearWithOld?.Invoke(oldItems);
            runtimeSet.onClear?.Invoke();
        }
    }
}