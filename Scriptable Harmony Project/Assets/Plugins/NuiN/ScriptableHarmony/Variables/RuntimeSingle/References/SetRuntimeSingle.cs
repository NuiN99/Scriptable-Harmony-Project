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

        public void Set(T newItem, bool invokeActions = true, bool overrideExisting = true)
        {
            if (newItem == null) return;
            if (Entity != null && !overrideExisting) return;

            T oldItem = Entity;
            Entity = newItem;
            
            if (!invokeActions) return;
            
            runtimeSingle.onSetWithOld?.Invoke(oldItem, Entity);
            runtimeSingle.onSet?.Invoke(Entity);
        }
        
        public void Remove(bool invokeActions = true)
        {
            if (Entity == null) return;

            T oldItem = Entity;
            Entity = null;
            
            if (!invokeActions) return;
            
            runtimeSingle.onRemoveWithOld?.Invoke(oldItem);
            runtimeSingle.onRemove?.Invoke();
        }
    }
}