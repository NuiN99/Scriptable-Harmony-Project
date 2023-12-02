using NuiN.ScriptableVariables.Core.RuntimeSet.References;
using UnityEngine;

namespace NuiN.ScriptableVariables.Core.RuntimeSet.Components.Base
{
    public class RuntimeSingleItemComponentBase<T> : MonoBehaviour where T : Object
    {
        enum Type{ OnEnableOnDisable, OnAwakeOnDestroy }
    
        [SerializeField] T thisObject;
    
        [SerializeField] RuntimeSingleWriter<T> runtimeSingle;
        [SerializeField] Type lifetimeType;

        [SerializeField] bool overwriteExisting;
        
        [Header("Actions")]
        [SerializeField] bool invokeOnSet = true;
        [SerializeField] bool invokeOnRemove = true;
    
        void OnEnable() => SetItem(Type.OnEnableOnDisable);
        void OnDisable() => RemoveFromSet(Type.OnEnableOnDisable);

        void Awake() => SetItem(Type.OnAwakeOnDestroy);
        void OnDestroy() => RemoveFromSet(Type.OnAwakeOnDestroy);

        void SetItem(Type type)
        {
            if (SelfDestructIfNullObject(thisObject)) return;
            if (lifetimeType != type) return;
            runtimeSingle.Set(thisObject, invokeOnSet, overwriteExisting);
        }
        void RemoveFromSet(Type type)
        {
            if (lifetimeType != type) return;
            runtimeSingle.Remove(invokeOnRemove);
        }

        bool SelfDestructIfNullObject(T obj)
        {
            if (obj != null) return false;
        
            Debug.LogError($"Self Destructing: Component of type {typeof(T).Name} not found on {gameObject.name}", gameObject);
            Destroy(this);
            return true;
        }
    }
}

