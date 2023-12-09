using System;
using NuiN.ScriptableVariables.Internal.Attributes;
using NuiN.ScriptableVariables.Internal.Helpers;
using NuiN.ScriptableVariables.ListVariable.References.Base;
using NuiN.ScriptableVariables.References;
using NuiN.ScriptableVariables.RuntimeSingle.Components.Base;
using NuiN.ScriptableVariables.RuntimeSingle.References;
using NuiN.ScriptableVariables.RuntimeSingle.References.Base;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace NuiN.ScriptableVariables.RuntimeSingle.Base
{
    public class RuntimeSingleBaseSO<T> : RuntimeBaseBase<T> where T : Object
    {
        [SerializeField] [TextArea] string description;

        [TypeMismatchFix]
        public T runtimeSingle;

        [SerializeField] RuntimeSetReferencesContainer componentHolders = 
            new("runtimeSingle", typeof(RuntimeSingleItemComponentBase<T>), typeof(SetRuntimeSingle<T>));

        protected override RuntimeSetReferencesContainer ComponentHolders
        {
            get => componentHolders; 
            set => componentHolders = value;
        }
        
        public Action<T> onSet;
        public Action<T, T> onSetWithOld;
        
        public Action onRemove;
        public Action<T> onRemoveWithOld;
        

        protected override void ResetValue()
        {
            runtimeSingle = null;
        }

        [SerializeField] ReadWriteReferencesContainer gettersAndSetters = 
            new("runtimeSingle", typeof(ReferenceRuntimeSingleBase<T>), typeof(GetRuntimeSingle<T>), typeof(SetRuntimeSingle<T>));

        protected override ReadWriteReferencesContainer GettersAndSetters
        {
            get => gettersAndSetters; 
            set => gettersAndSetters = value;
        }
    }
}


