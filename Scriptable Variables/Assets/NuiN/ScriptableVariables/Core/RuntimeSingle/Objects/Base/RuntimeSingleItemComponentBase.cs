using NuiN.ScriptableVariables.Core.RuntimeSet.Components.Base;
using NuiN.ScriptableVariables.RuntimeSingle.References;
using UnityEngine;

namespace NuiN.ScriptableVariables.Core.RuntimeSingle.Components.Base
{
    public class RuntimeSingleItemComponentBase<T> : MonoBehaviour where T : Object
    {
        enum Type{ OnEnableOnDisable, OnAwakeOnDestroy }
    
        [SerializeField] T thisObject;
    
        [SerializeField] SetRuntimeSingle<T> runtimeSingle;
        [SerializeField] Type lifetimeType;

        [SerializeField] bool overwriteExisting;
        
        [Header("Actions")]
        [SerializeField] bool dontInvokeOnSet;
        [SerializeField] bool dontInvokeOnRemove;
    
        void OnEnable() => SetItem(Type.OnEnableOnDisable);
        void OnDisable() => RemoveFromSet(Type.OnEnableOnDisable);

        void Awake()
        {
            SetItem(Type.OnAwakeOnDestroy);
        }

        void OnDestroy() => RemoveFromSet(lifetimeType);

        void SetItem(Type type)
        {
            if (SelfDestructIfNullObject(thisObject)) return;
            if (lifetimeType != type) return;
            runtimeSingle.Set(thisObject, !dontInvokeOnSet, overwriteExisting);
        }
        void RemoveFromSet(Type type)
        {
            if (lifetimeType != type) return;
            runtimeSingle.Remove(!dontInvokeOnRemove);
        }

        bool SelfDestructIfNullObject(T obj)
        {
            if (obj != null) return false;
        
            Debug.LogError($"Self Destructing: {typeof(T).Name} object not assigned in {gameObject.name}'s RuntimeSingle Component", gameObject);
            Destroy(this);
            return true;
        }
    }
}

