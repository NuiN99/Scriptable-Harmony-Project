using System;
using NuiN.ScriptableHarmony.Base;
using NuiN.ScriptableHarmony.Editor.Attributes;
using NuiN.ScriptableHarmony.Internal.Helpers;
using NuiN.ScriptableHarmony.References;
using NuiN.ScriptableHarmony.RuntimeSingle.Components.Base;
using NuiN.ScriptableHarmony.RuntimeSingle.References.Base;
using UnityEngine;
using Object = UnityEngine.Object;

namespace NuiN.ScriptableHarmony.RuntimeSingle.Base
{
    public class RuntimeSingleBaseSO<T> : RuntimeObjectBaseSO<T> where T : Object
    {
        [SerializeField] [TextArea] string description;

        [TypeMismatchFix] public T runtimeSingle;
        
        public Action<T> onSet;
        public Action<T, T> onSetWithOld;
        
        public Action onRemove;
        public Action<T> onRemoveWithOld;

        [Header("Debugging")]
        [SerializeField] RuntimeSetReferencesContainer componentHolders = new("runtimeSingle", typeof(RuntimeSingleItemComponentBase<T>), typeof(SetRuntimeSingle<T>));
        [SerializeField] GetSetReferencesContainer gettersAndSetters = new("runtimeSingle", typeof(ReferenceRuntimeSingleBase<T>), typeof(GetRuntimeSingle<T>), typeof(SetRuntimeSingle<T>));
        protected override RuntimeSetReferencesContainer ComponentHolders { get => componentHolders; set => componentHolders = value; }
        protected override GetSetReferencesContainer GettersAndSetters { get => gettersAndSetters; set => gettersAndSetters = value; }
        
        protected override void ResetValue() => runtimeSingle = null;
    }
}


