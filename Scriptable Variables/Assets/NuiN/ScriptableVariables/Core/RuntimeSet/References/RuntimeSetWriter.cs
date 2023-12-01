using System;
using System.Collections.Generic;
using NuiN.ScriptableVariables.Core.RuntimeSet.References.Base;
using Object = UnityEngine.Object;

namespace NuiN.ScriptableVariables.Core.RuntimeSet.References
{
    [Serializable]
    public class RuntimeSetWriter<T> : RuntimeSetReferenceBase<T> where T : Object
    {
        public List<T> Items => runtimeSet.items;
    
        public void Add(T item, bool invokeActions = true, bool returnIfContains = true)
        {
            if (item == null) return;
            if (returnIfContains && Items.Contains(item)) return;
        
            List<T> oldItems = Items;
            Items.Add(item);

            if (!invokeActions) return;
        
            runtimeSet.onAddWithOld?.Invoke(oldItems, item);
            runtimeSet.onAdd?.Invoke(item);
        }
    
        public void Remove(T item, bool invokeActions = true, bool returnIfDoesntContain = true)
        {
            if (returnIfDoesntContain && !Items.Contains(item)) return;
        
            List<T> oldItems = Items;
            Items.Remove(item);
        
            if (!invokeActions) return;
        
            runtimeSet.onRemoveWithOld?.Invoke(oldItems, item);
            runtimeSet.onRemove?.Invoke(item);
        }

        public void Clear(bool invokeActions = true)
        {
            List<T> oldItems = Items;
            Items.Clear();

            if (!invokeActions) return;
        
            runtimeSet.onClearWithOld?.Invoke(oldItems);
            runtimeSet.onClear?.Invoke();
        }
    }
}