using System;
using System.Collections.Generic;
using NuiN.ScriptableHarmony.Base;
using NuiN.ScriptableHarmony.Internal.Attributes;
using NuiN.ScriptableHarmony.Internal.Helpers;
using NuiN.ScriptableHarmony.References;
using NuiN.ScriptableHarmony.RuntimeSet.Components.Base;
using NuiN.ScriptableHarmony.RuntimeSet.References.Base;
using UnityEngine;
using Object = UnityEngine.Object;

namespace NuiN.ScriptableHarmony.RuntimeSet.Base
{
    public class RuntimeSetBaseSO<T> : RuntimeObjectBaseSO<T> where T : Object
    {
        [SerializeField] [TextArea] string description;
        
        [TypeMismatchFix] public List<T> runtimeSet = new();

        public Action<T> onAdd;
        public Action<List<T>, T> onAddWithOld;

        public Action<T> onRemove;
        public Action<List<T>, T> onRemoveWithOld;

        public Action onClear;
        public Action<List<T>> onClearWithOld;
        
        [Header("Debug References")]
        [SerializeField] RuntimeSetReferencesContainer componentHolders = new("runtimeSet", typeof(RuntimeSetItemComponentBase<T>), typeof(SetRuntimeSet<T>));
        [SerializeField] ReadWriteReferencesContainer gettersAndSetters = new("runtimeSet", typeof(ReferenceRuntimeSetBase<T>), typeof(GetRuntimeSet<T>), typeof(SetRuntimeSet<T>));
        protected override RuntimeSetReferencesContainer ComponentHolders { get => componentHolders; set => componentHolders = value; }
        protected override ReadWriteReferencesContainer GettersAndSetters { get => gettersAndSetters; set => gettersAndSetters = value; }
        
        protected override void ResetValue() => runtimeSet.Clear();
    }
}

