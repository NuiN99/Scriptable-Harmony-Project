using System;
using NuiN.ScriptableHarmony.RuntimeSingle.References.Base;
using Object = UnityEngine.Object;

namespace NuiN.ScriptableHarmony.References
{
    [Serializable]
    public class SetRuntimeSingle<T> : ReferenceRuntimeSingleBase<T> where T : Object
    {
        public T Entity
        {
            get => runtimeSingle.runtimeSingle;
            private set => runtimeSingle.runtimeSingle = value;
        }

        void Set(T newItem, bool overrideExisting, bool invokeActions)
        {
            if (newItem == null) return;
            if (Entity != null && !overrideExisting) return;

            T oldItem = Entity;
            Entity = newItem;
            
            if (!invokeActions) return;
            
            runtimeSingle.onSetWithOld?.Invoke(oldItem, Entity);
            runtimeSingle.onSet?.Invoke(Entity);
        }
        public void TrySet(T newItem)
            => Set(newItem, false, true);
        public void TrySetNoInvoke(T newItem)
            => Set(newItem, false, false);
        public void Set(T newItem)
            => Set(newItem, true, true);
        public void SetNoInvoke(T newItem, bool invokeActions = true, bool overrideExisting = true)
            => Set(newItem, true, false);
        
        void Remove(bool invokeActions)
        {
            if (Entity == null) return;

            T oldItem = Entity;
            Entity = null;
            
            if (!invokeActions) return;
            
            runtimeSingle.onRemoveWithOld?.Invoke(oldItem);
            runtimeSingle.onRemove?.Invoke();
        }
        public void Remove() => Remove(true);
        public void RemoveNoInvoke() => Remove(false);
    }
}