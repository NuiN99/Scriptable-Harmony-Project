using System;
using System.Collections.Generic;
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
        public List<T> values = new();
        [SerializeField] [ReadOnlyPlayMode] List<T> defaultValues = new();
        
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
        
        [Header("Debugging")]
        [SerializeField] GetSetReferencesContainer gettersAndSetters = new("list", typeof(ReferenceScriptableListVariableBase<T>), typeof(GetListVariable<T>), typeof(SetListVariable<T>));
        protected override GetSetReferencesContainer GettersAndSetters { get => gettersAndSetters;set => gettersAndSetters = value; }
        
        [SOMethodButton("Save List")]
        public void SaveValueButton()
        {
            defaultValues = new List<T>(values);
        }
        
        protected override void CacheInitialValue() => defaultValues = new List<T>(values);
        protected override void ResetValue() => values = new List<T>(defaultValues);
        protected override bool ResetOnSceneLoad() => resetOnSceneLoad;
    }
}
