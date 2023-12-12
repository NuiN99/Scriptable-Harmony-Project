using NuiN.ScriptableHarmony.References;
using NuiN.ScriptableHarmony.RuntimeSet.References;
using UnityEngine;

namespace NuiN.ScriptableHarmony.RuntimeSet.Components.Base
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
            
            if(!dontInvokeOnAdd) runtimeSet.Add(thisObject);
            else runtimeSet.AddNoInvoke(thisObject);
        }
        void RemoveFromSet(Type type)
        {
            if (lifetimeType != type) return;
            runtimeSet.Remove(thisObject);
            
            if(!dontInvokeOnRemove) runtimeSet.Remove(thisObject);
            else runtimeSet.RemoveNoInvoke(thisObject);
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

