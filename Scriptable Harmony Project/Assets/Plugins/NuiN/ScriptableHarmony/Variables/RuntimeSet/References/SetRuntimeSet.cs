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
        
            runtimeSet.onAddWithOld?.Invoke(oldItems, item);
            runtimeSet.onAdd?.Invoke(item);
        }
    
        public void Remove(T item, bool invokeActions = true, bool returnIfDoesntContain = true)
        {
            if (returnIfDoesntContain && !Entities.Contains(item)) return;
        
            List<T> oldItems = Entities;
            Entities.Remove(item);
        
            if (!invokeActions) return;
        
            runtimeSet.onRemoveWithOld?.Invoke(oldItems, item);
            runtimeSet.onRemove?.Invoke(item);
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