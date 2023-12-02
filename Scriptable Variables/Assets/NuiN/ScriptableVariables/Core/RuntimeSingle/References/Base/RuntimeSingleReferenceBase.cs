using System;
using System.Collections.Generic;
using NuiN.ScriptableVariables.Core.RuntimeSet.ScriptableObjectClasses.Base;
using UnityEngine;
using Object = UnityEngine.Object;

namespace NuiN.ScriptableVariables.Core.RuntimeSet.References.Base
{
    [Serializable]
    public class RuntimeSingleReferenceBase<T> where T : Object
    {
        [SerializeField] protected RuntimeSingleBaseSO<T> runtimeSingle;
        
        public void SubOnSet(Action<T> onSet) => runtimeSingle.onSet += onSet;
        public void UnsubOnSet(Action<T> onSet) => runtimeSingle.onSet -= onSet;
        
        public void SubOnSetWithOld(Action<T,T> onSetWithOld) => runtimeSingle.onSetWithOld += onSetWithOld;
        public void UnsubOnSetWithOld(Action<T,T> onSetWithOld) => runtimeSingle.onSetWithOld -= onSetWithOld;
        
        public void SubOnRemove(Action onRemove) => runtimeSingle.onRemove += onRemove;
        public void UnsubOnRemove(Action onRemove) => runtimeSingle.onRemove -= onRemove;
        
        public void SubOnRemoveWithOld(Action<T> onRemoveWithOld) => runtimeSingle.onRemoveWithOld += onRemoveWithOld;
        public void UnsubOnRemoveWithOld(Action<T> onRemoveWithOld) => runtimeSingle.onRemoveWithOld -= onRemoveWithOld;
    }
}