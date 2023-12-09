using System;
using System.Collections.Generic;
using NuiN.ScriptableVariables.Base;
using NuiN.ScriptableVariables.Internal.Helpers;
using NuiN.ScriptableVariables.ListVariable.References.Base;
using NuiN.ScriptableVariables.References;
using UnityEngine;

namespace NuiN.ScriptableVariables.ListVariable.Base
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

        public Action<T> onRemove;
        public Action<List<T>,T> onRemoveWithOld;

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
