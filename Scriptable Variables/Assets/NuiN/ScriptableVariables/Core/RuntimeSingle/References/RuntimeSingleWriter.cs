using System;
using NuiN.ScriptableVariables.RuntimeSingle.References.Base;
using Object = UnityEngine.Object;

namespace NuiN.ScriptableVariables.RuntimeSingle.References
{
    [Serializable]
    public class RuntimeSingleWriter<T> : RuntimeSingleReferenceBase<T> where T : Object
    {
        public T Item
        {
            get => runtimeSingle.item;
            private set => runtimeSingle.item = value;
        }

        public void Set(T newItem, bool invokeActions = true, bool overrideExisting = true)
        {
            if (newItem == null) return;
            if (Item != null && !overrideExisting) return;

            T oldItem = Item;
            Item = newItem;
            
            if (!invokeActions) return;
            
            runtimeSingle.onSetWithOld?.Invoke(oldItem, Item);
            runtimeSingle.onSet?.Invoke(Item);
        }
        
        public void Remove(bool invokeActions = true)
        {
            if (Item == null) return;

            T oldItem = Item;
            Item = null;
            
            if (!invokeActions) return;
            
            runtimeSingle.onRemoveWithOld?.Invoke(oldItem);
            runtimeSingle.onRemove?.Invoke();
        }
    }
}