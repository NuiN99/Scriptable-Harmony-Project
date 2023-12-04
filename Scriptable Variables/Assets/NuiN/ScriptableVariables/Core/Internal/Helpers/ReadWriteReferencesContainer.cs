using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace NuiN.ScriptableVariables.Internal.Helpers
{
#if UNITY_EDITOR
    [Serializable]
    internal class ReadWriteReferencesContainer : ReferencesContainerBase
    {
        Type _getterType;
        Type _setterType;
        
        [Header("Prefabs")]
        public List<Component> Getters;
        public List<Component> Setters;
            
        [Header("Scene")]
        public List<Component> getters;
        public List<Component> setters;
        
        public ReadWriteReferencesContainer(string fieldName, Type baseType, Type getterType, Type setterType) : base(fieldName, baseType)
        {
            _setterType = setterType;
            _getterType = getterType;
        }
        
        public override int TotalReferencesCount() => Setters.Count + Getters.Count + setters.Count + getters.Count;

        public override bool ListsAreNull() => Setters == null || Getters == null || setters == null || getters == null;

        public override void Clear()
        {
            Getters?.Clear();
            Setters?.Clear();
            getters?.Clear();
            setters?.Clear();
        }
        
        protected override void CheckComponentAndAssign(object variableCaller, Component component, ObjectsToSearch objectsToSearch)
        {
            Type componentType = component.GetType();
            FieldInfo[] fields =
                componentType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (var field in fields)
            {
                Type type = field.FieldType;
                if (!type.IsGenericType) continue;

                bool isGetter = type == _getterType;
                bool isSetter = type == _setterType;

                if (!isGetter && !isSetter) continue;
                        
                object variableField = field.GetValue(component);
                if (variableField == null || (!_getterType.IsInstanceOfType(variableField) && !_setterType.IsInstanceOfType(variableField))) return;

                FieldInfo variableFieldInfo =
                    baseType.GetField(fieldName,
                        BindingFlags.Instance | BindingFlags.NonPublic);

                if (variableFieldInfo == null ||
                    !ReferenceEquals(variableFieldInfo.GetValue(variableField), variableCaller)) continue;

                switch (objectsToSearch)
                {
                    case ObjectsToSearch.Prefabs when isGetter:Getters?.Add(component); break;
                    case ObjectsToSearch.Prefabs: Setters?.Add(component); break;
                    case ObjectsToSearch.Scene when isGetter: getters?.Add(component); break;
                    case ObjectsToSearch.Scene: setters?.Add(component); break;
                }
            }
        }
    }
#endif
}
