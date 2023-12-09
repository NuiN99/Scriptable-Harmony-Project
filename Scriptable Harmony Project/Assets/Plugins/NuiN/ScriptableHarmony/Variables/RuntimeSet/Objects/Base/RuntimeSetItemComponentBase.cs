using NuiN.ScriptableVariables.References;
using NuiN.ScriptableVariables.RuntimeSet.References;
using UnityEngine;

namespace NuiN.ScriptableVariables.RuntimeSet.Components.Base
{
    public class RuntimeSetItemComponentBase<T> : MonoBehaviour where T : Object
    {
        enum Type{ OnEnableOnDisable, OnAwakeOnDestroy }
    
        [SerializeField] T thisObject;
    
        [SerializeField] SetRuntimeSet<T> runtimeSet;
        [SerializeField] Type lifetimeType;
        
        [Header("Actions")]
        [SerializeField] bool dontInvokeOnAdd;
        [SerializeField] bool dontInvokeOnRemove;
    
        void OnEnable() => AddToSet(Type.OnEnableOnDisable);
        void OnDisable() => RemoveFromSet(Type.OnEnableOnDisable);

        void Awake() => AddToSet(Type.OnAwakeOnDestroy);
        void OnDestroy() => RemoveFromSet(lifetimeType);

        void AddToSet(Type type)
        {
            if (SelfDestructIfNullObject(thisObject)) return;
            if (lifetimeType != type) return;
            runtimeSet.Add(thisObject, !dontInvokeOnAdd);
        }
        void RemoveFromSet(Type type)
        {
            if (lifetimeType != type) return;
            runtimeSet.Remove(thisObject, !dontInvokeOnRemove);
        }

        bool SelfDestructIfNullObject(T obj)
        {
            if (obj != null) return false;
        
            Debug.LogError($"Self Destructing: {typeof(T).Name} object not assigned in {gameObject.name}'s RuntimeSet Component", gameObject);
            Destroy(this);
            return true;
        }
    }
}

