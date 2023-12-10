using System;
using System.Collections.Generic;
using NuiN.ScriptableHarmony.Base;
using NuiN.ScriptableHarmony.Internal.Helpers;
using NuiN.ScriptableHarmony.ListVariable.References.Base;
using NuiN.ScriptableHarmony.References;
using UnityEngine;

namespace NuiN.ScriptableHarmony.ListVariable.Base
{
    public class ScriptableListVariableBaseSO<T> : VariableObjectBaseSO<T>
    {
        List<T> _startValue = new();
        public List<T> list = new();
        
        [Header("Value Persistence")]
        [SerializeField] bool resetOnSceneLoad = true;
        [SerializeField] bool resetOnExitPlaymode = true;
        
        public Action<List<T>> onSet;
        public Action<List<T>, List<T>> onSetWithOld;
        
        public Action<T> onAdd;
        public Action<List<T>,T> onAddWithOld;
        
        public Action<List<T>> onAddWithList;
        public Action<List<T>,List<T>> onAddWithListWithOld;

        public Action<T> onRemove;
        public Action<List<T>,T> onRemoveWithOld;
        
        public Action<List<T>> onRemoveWithList;
        public Action<List<T>,List<T>> onRemoveWithListWithOld;

        public Action onClear;
        public Action<List<T>> onClearWithOld;
        
        [Header("Debug References")]
        [SerializeField] ReadWriteReferencesContainer gettersAndSetters = new("list", typeof(ReferenceScriptableListVariableBase<T>), typeof(GetListVariable<T>), typeof(SetListVariable<T>));
        protected override ReadWriteReferencesContainer GettersAndSetters { get => gettersAndSetters;set => gettersAndSetters = value; }

        protected override void CacheStartValue() => _startValue = new List<T>(list);
        protected override void ResetValue() => list = new List<T>(_startValue);
        
        protected override bool ResetOnSceneLoad() => resetOnSceneLoad;
        protected override bool ResetOnExitPlayMode() => resetOnExitPlaymode;
    }
}
