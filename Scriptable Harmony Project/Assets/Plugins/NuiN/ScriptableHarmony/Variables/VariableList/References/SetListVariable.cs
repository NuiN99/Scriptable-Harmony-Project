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
            List<T> oldValue = list.list;
            list.list = newList;
            
            SetDirty();

            if (!invokeActions) return;
            
            list.onSetWithOld?.Invoke(oldValue, newList);
            list.onSet?.Invoke(newList);
        }
        
        public void Add(T item, bool invokeActions = true)
        {
            List<T> oldValue = list.list;
            list.list.Add(item);
            
            SetDirty();

            if (!invokeActions) return;
            
            list.onAddWithOld?.Invoke(oldValue, item);
            list.onAdd?.Invoke(item);
        }

        public void Insert(T item, int index, bool invokeActions = true)
        {
            List<T> oldValue = list.list;
            list.list.Insert(index, item);
            
            SetDirty();

            if (!invokeActions) return;
            
            list.onAddWithOld?.Invoke(oldValue, item);
            list.onAdd?.Invoke(item);
        }

        public void RemoveAt(int index, bool invokeActions = true)
        {
            List<T> oldValue = list.list;

            T removedItem = list.list[index];
            list.list.RemoveAt(index);
            
            SetDirty();

            if (!invokeActions) return;
            
            list.onRemoveWithOld?.Invoke(oldValue, removedItem);
            list.onRemove?.Invoke(removedItem);
        }
        
        public void Remove(T item, bool invokeActions = true)
        {
            List<T> oldValue = list.list;
            list.list.Remove(item);
            
            SetDirty();

            if (!invokeActions) return;
            
            list.onRemoveWithOld?.Invoke(oldValue, item);
            list.onRemove?.Invoke(item);
        }
        
        public void Clear(bool invokeActions = true)
        {
            List<T> oldValue = list.list;
            list.list.Clear();
            
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
