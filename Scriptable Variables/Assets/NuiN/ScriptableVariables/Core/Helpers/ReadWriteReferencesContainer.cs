using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace NuiN.ScriptableVariables.Core.Helpers
{
#if UNITY_EDITOR
    [Serializable]
    internal class ReadWriteReferencesContainer : ReferencesContainerBase
    {
        Type _getterType;
        Type _setterType;
        
        [Header("Prefabs")]
        // ReSharper disable once InconsistentNaming
        public List<Component> Setters;
        // ReSharper disable once InconsistentNaming
        public List<Component> Getters;
            
        [Header("Scene")]
        public List<Component> setters;
        public List<Component> getters;
            
        public override int TotalReferencesCount() => Setters.Count + Getters.Count + setters.Count + getters.Count;

        public override bool ListsAreNull() => Setters == null || Getters == null || setters == null || getters == null;

        public ReadWriteReferencesContainer(string fieldName, Type baseType, Type getterType, Type setterType) : base(fieldName, baseType)
        {
            _setterType = setterType;
            _getterType = getterType;
        }

        public override void Clear()
        {
            Getters?.Clear();
            Setters?.Clear();
            getters?.Clear();
            setters?.Clear();
        }

        
        public override void CheckComponentAndAssign(object variableCaller, Component component, bool prefabs)
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

                if (prefabs)
                {
                    if (isGetter) Getters.Add(component);
                    else Setters.Add(component);
                }
                else
                {
                    if (isGetter) getters.Add(component);
                    else setters.Add(component);
                }
            }
        }
    }
#endif
}
