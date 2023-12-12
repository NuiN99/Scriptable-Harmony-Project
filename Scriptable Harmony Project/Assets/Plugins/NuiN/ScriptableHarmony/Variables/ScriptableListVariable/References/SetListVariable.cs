using System;
using System.Collections.Generic;
using System.Diagnostics;
using NuiN.ScriptableHarmony.ListVariable.Base;
using NuiN.ScriptableHarmony.ListVariable.References.Base;
using UnityEditor;
using Debug = UnityEngine.Debug;

namespace NuiN.ScriptableHarmony.References
{
    [Serializable]
    public class SetListVariable<T> : ReferenceScriptableListVariableBase<T>
    {
        public List<T> Items => list.items;
        
        public void Add(T item)
        {
            var oldValue = new List<T>(Items);
            Items.Add(item);
            SetDirty();

            list.onAddWithListWithOld?.Invoke(oldValue, Items);
            list.onAddWithOld?.Invoke(oldValue, item);
            list.onAddWithList?.Invoke(Items);
            list.onAdd?.Invoke(item);
        }
        public void AddNoInvoke(T item)
        {
            Items.Add(item);
            SetDirty();
        }

        public void Insert(T item, int index)
        {
            var oldValue = new List<T>(Items);
            Items.Insert(index, item);
            SetDirty();

            list.onAddWithListWithOld?.Invoke(oldValue, Items);
            list.onAddWithOld?.Invoke(oldValue, item);
            list.onAddWithList?.Invoke(Items);
            list.onAdd?.Invoke(item);
        }
        public void InsertNoInvoke(T item, int index)
        {
            Items.Insert(index, item);
            SetDirty();
        }

        public void RemoveAt(int index)
        {
            var oldValue = new List<T>(Items);

            T removedItem = Items[index];
            Items.RemoveAt(index);
            SetDirty();

            list.onRemoveWithListWithOld?.Invoke(oldValue, Items);
            list.onRemoveWithOld?.Invoke(oldValue, removedItem);
            list.onRemoveWithList?.Invoke(Items);
            list.onRemove?.Invoke(removedItem);
        }
        public void RemoveAtNoInvoke(int index)
        {
            Items.RemoveAt(index);
            SetDirty();
        }
        
        public void Remove(T item)
        {
            var oldValue = new List<T>(Items);
            Items.Remove(item);
            SetDirty();

            list.onRemoveWithListWithOld?.Invoke(oldValue, Items);
            list.onRemoveWithOld?.Invoke(oldValue, item);
            list.onRemoveWithList?.Invoke(Items);
            list.onRemove?.Invoke(item);
        }
        public void RemoveNoInvoke(T item)
        {
            Items.Remove(item);
            SetDirty();
        }
        
        public void Replace(List<T> newList)
        {
            Clear();
            foreach(var item in newList) Add(item);
        }
        public void ReplaceNoInvoke(List<T> newList)
        {
            ClearNoInvoke();
            foreach(var item in newList) AddNoInvoke(item);
        }
        
        public void Clear()
        {
            for(int i = Items.Count-1; i >= 0; i--) Remove(Items[i]);
        }
        public void ClearNoInvoke()
        {
            for(int i = Items.Count-1; i >= 0; i--) RemoveNoInvoke(Items[i]);
        }

        [Conditional("UNITY_EDITOR")]
        void SetDirty()
        {
            EditorUtility.SetDirty(list);
        }
    }
}
