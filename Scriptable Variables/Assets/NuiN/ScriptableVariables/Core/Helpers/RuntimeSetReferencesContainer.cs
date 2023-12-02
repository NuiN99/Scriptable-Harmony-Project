using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace NuiN.ScriptableVariables.Core.Helpers
{
#if UNITY_EDITOR
    [Serializable]
    internal class RuntimeSetReferencesContainer : ReferencesContainerBase
    {
        public List<Component> prefabItems;
        public List<Component> sceneItems;
        
        Type _writerType;

        public RuntimeSetReferencesContainer(string fieldName, Type baseType, Type writerType) : base(fieldName, baseType)
        {
            _writerType = writerType;
        }
        
        public override int TotalReferencesCount() => prefabItems.Count + sceneItems.Count;

        public override bool ListsAreNull() => prefabItems == null || sceneItems == null;

        public override void Clear()
        {
            prefabItems?.Clear();
            sceneItems?.Clear();
        }
        
        protected override void CheckComponentAndAssign(object variableCaller, Component component, ObjectsToSearch objectsToSearch)
        {
            Type componentType = component.GetType();
            
            Type componentBaseType = componentType.BaseType;
            if (componentBaseType == null || componentBaseType != baseType) return;
            
            FieldInfo[] fields =
                baseType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (var field in fields)
            {
                Type type = field.FieldType;
                if (!type.IsGenericType) continue;

                object variableField = field.GetValue(component);
                if (variableField == null || !_writerType.IsInstanceOfType(variableField)) continue;

                FieldInfo variableFieldInfo =
                    _writerType.GetField(fieldName,
                        BindingFlags.Instance | BindingFlags.NonPublic);

                if (variableFieldInfo == null ||
                    !ReferenceEquals(variableFieldInfo.GetValue(variableField), variableCaller)) continue;

                switch (objectsToSearch)
                {
                    case ObjectsToSearch.Prefabs: prefabItems?.Add(component); break;
                    case ObjectsToSearch.Scene: sceneItems?.Add(component); break;
                }
            }
        }
    }
#endif
}
