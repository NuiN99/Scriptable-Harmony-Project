using NuiN.ScriptableVariables.RuntimeSet.References;
using UnityEngine;

namespace NuiN.ScriptableVariables.Core.RuntimeSet.Components.Base
{
    public class RuntimeSetItemComponentBase<T> : MonoBehaviour where T : Object
    {
        enum Type{ OnEnableOnDisable, OnAwakeOnDestroy }
    
        [SerializeField] T thisObject;
    
        [SerializeField] RuntimeSetWriter<T> runtimeSet;
        [SerializeField] Type lifetimeType;

        [Header("Actions")]
        [SerializeField] bool invokeOnAdd = true;
        [SerializeField] bool invokeOnRemove = true;
    
        void OnEnable() => AddToSet(Type.OnEnableOnDisable);
        void OnDisable() => RemoveFromSet(Type.OnEnableOnDisable);

        void Awake() => AddToSet(Type.OnAwakeOnDestroy);
        void OnDestroy() => RemoveFromSet(Type.OnAwakeOnDestroy);

        void AddToSet(Type type)
        {
            if (SelfDestructIfNullObject(thisObject)) return;
            if (lifetimeType != type) return;
            runtimeSet.Add(thisObject, invokeOnAdd);
        }
        void RemoveFromSet(Type type)
        {
            if (lifetimeType != type) return;
            runtimeSet.Remove(thisObject, invokeOnRemove);
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

