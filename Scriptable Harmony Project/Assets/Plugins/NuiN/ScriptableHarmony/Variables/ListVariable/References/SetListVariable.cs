using System;
using System.Collections.Generic;
using NuiN.ScriptableHarmony.ListVariable.References.Base;
using NuiN.ScriptableHarmony.Variable.References.Base;
using UnityEditor;

namespace NuiN.ScriptableHarmony.References
{
    [Serializable]
    public class SetListVariable<T> : ReferenceScriptableListVariableBase<T>
    {
        public List<T> Items => list.list;

        public void Set(List<T> newList, bool invokeActions = true)
        {
            List<T> oldValue = Items;
            list.list = newList;
            
            SetDirty();

            if (!invokeActions) return;
            
            list.onSetWithOld?.Invoke(oldValue, newList);
            list.onSet?.Invoke(newList);
        }
        
        public void Add(T item, bool invokeActions = true)
        {
            List<T> oldValue = Items;
            Items.Add(item);
            
            SetDirty();

            if (!invokeActions) return;
            
            list.onAddWithListWithOld?.Invoke(oldValue, Items);
            list.onAddWithOld?.Invoke(oldValue, item);
            list.onAddWithList?.Invoke(Items);
            list.onAdd?.Invoke(item);
        }

        public void Insert(T item, int index, bool invokeActions = true)
        {
            List<T> oldValue = Items;
            Items.Insert(index, item);
            
            SetDirty();

            if (!invokeActions) return;
            
            list.onAddWithListWithOld?.Invoke(oldValue, Items);
            list.onAddWithOld?.Invoke(oldValue, item);
            list.onAddWithList?.Invoke(Items);
            list.onAdd?.Invoke(item);
        }

        public void RemoveAt(int index, bool invokeActions = true)
        {
            List<T> oldValue = Items;

            T removedItem = Items[index];
            Items.RemoveAt(index);
            
            SetDirty();

            if (!invokeActions) return;
            
            list.onRemoveWithListWithOld?.Invoke(oldValue, Items);
            list.onRemoveWithOld?.Invoke(oldValue, removedItem);
            list.onRemoveWithList?.Invoke(Items);
            list.onRemove?.Invoke(removedItem);
        }
        
        public void Remove(T item, bool invokeActions = true)
        {
            List<T> oldValue = Items;
            Items.Remove(item);
            
            SetDirty();

            if (!invokeActions) return;
            
            list.onRemoveWithListWithOld?.Invoke(oldValue, Items);
            list.onRemoveWithOld?.Invoke(oldValue, item);
            list.onRemoveWithList?.Invoke(Items);
            list.onRemove?.Invoke(item);
        }
        
        public void Clear(bool invokeActions = true)
        {
            List<T> oldValue = Items;
            Items.Clear();
            
            SetDirty();

            if (!invokeActions) return;
            
            list.onClearWithOld?.Invoke(oldValue);
            list.onClear?.Invoke();
        }

        void SetDirty()
        {
#if UNITY_EDITOR
            EditorUtility.SetDirty(list);
#endif
        }
    }
}
