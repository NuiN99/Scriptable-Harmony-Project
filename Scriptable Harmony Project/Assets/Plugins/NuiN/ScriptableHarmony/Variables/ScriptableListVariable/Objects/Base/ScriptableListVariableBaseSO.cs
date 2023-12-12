using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NuiN.ScriptableHarmony.Base;
using NuiN.ScriptableHarmony.Editor.Attributes;
using NuiN.ScriptableHarmony.Internal.Helpers;
using NuiN.ScriptableHarmony.ListVariable.References.Base;
using NuiN.ScriptableHarmony.References;
using UnityEngine;

namespace NuiN.ScriptableHarmony.ListVariable.Base
{
    public class ScriptableListVariableBaseSO<T> : ScriptableVariableLifetimeBaseSO<T>
    {
        List<T> _initialItems = new();
        public List<T> items = new();
        
        [Header("Value Persistence")]
        [SerializeField] bool resetOnSceneLoad = true;
        
        public Action<T> onAdd;
        public Action<List<T>,T> onAddWithOld;
        
        public Action<List<T>> onAddWithList;
        public Action<List<T>,List<T>> onAddWithListWithOld;

        public Action<T> onRemove;
        public Action<List<T>,T> onRemoveWithOld;
        
        public Action<List<T>> onRemoveWithList;
        public Action<List<T>,List<T>> onRemoveWithListWithOld;
        
        [Header("Debug References")]
        [SerializeField] ReadWriteReferencesContainer gettersAndSetters = new("list", typeof(ReferenceScriptableListVariableBase<T>), typeof(GetListVariable<T>), typeof(SetListVariable<T>));
        protected override ReadWriteReferencesContainer GettersAndSetters { get => gettersAndSetters;set => gettersAndSetters = value; }
        
        [SOMethodButton("Save List")]
        public void SaveValueButton()
        {
            _initialItems = new List<T>(items);
        }
        
        protected override void CacheInitialValue() => _initialItems = new List<T>(items);
        protected override void ResetValue() => items = new List<T>(_initialItems);
        protected override bool ResetOnSceneLoad() => resetOnSceneLoad;
    }
}
