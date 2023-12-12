using System;
using System.Collections.Generic;
using System.Diagnostics;
using NuiN.ScriptableHarmony.ListVariable.References.Base;
using UnityEditor;

namespace NuiN.ScriptableHarmony.References
{
    [Serializable]
    public class SetListVariable<T> : ReferenceScriptableListVariableBase<T>
    {
        public List<T> Values => list.values;
        
        public void Add(T item)
        {
            var oldValue = new List<T>(Values);
            Values.Add(item);
            SetDirty();

            list.onAddWithListWithOld?.Invoke(oldValue, Values);
            list.onAddWithOld?.Invoke(oldValue, item);
            list.onAddWithList?.Invoke(Values);
            list.onAdd?.Invoke(item);
        }
        public void AddNoInvoke(T item)
        {
            Values.Add(item);
            SetDirty();
        }

        public void Insert(T item, int index)
        {
            var oldValue = new List<T>(Values);
            Values.Insert(index, item);
            SetDirty();

            list.onAddWithListWithOld?.Invoke(oldValue, Values);
            list.onAddWithOld?.Invoke(oldValue, item);
            list.onAddWithList?.Invoke(Values);
            list.onAdd?.Invoke(item);
        }
        public void InsertNoInvoke(T item, int index)
        {
            Values.Insert(index, item);
            SetDirty();
        }

        public void RemoveAt(int index)
        {
            var oldValue = new List<T>(Values);

            T removedItem = Values[index];
            Values.RemoveAt(index);
            SetDirty();

            list.onRemoveWithListWithOld?.Invoke(oldValue, Values);
            list.onRemoveWithOld?.Invoke(oldValue, removedItem);
            list.onRemoveWithList?.Invoke(Values);
            list.onRemove?.Invoke(removedItem);
        }
        public void RemoveAtNoInvoke(int index)
        {
            Values.RemoveAt(index);
            SetDirty();
        }
        
        public void Remove(T item)
        {
            var oldValue = new List<T>(Values);
            Values.Remove(item);
            SetDirty();

            list.onRemoveWithListWithOld?.Invoke(oldValue, Values);
            list.onRemoveWithOld?.Invoke(oldValue, item);
            list.onRemoveWithList?.Invoke(Values);
            list.onRemove?.Invoke(item);
        }
        public void RemoveNoInvoke(T item)
        {
            Values.Remove(item);
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
            for(int i = Values.Count-1; i >= 0; i--) Remove(Values[i]);
        }
        public void ClearNoInvoke()
        {
            for(int i = Values.Count-1; i >= 0; i--) RemoveNoInvoke(Values[i]);
        }

        [Conditional("UNITY_EDITOR")]
        void SetDirty()
        {
            EditorUtility.SetDirty(list);
        }
    }
}
