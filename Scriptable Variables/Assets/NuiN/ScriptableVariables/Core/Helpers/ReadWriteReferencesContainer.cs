using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace NuiN.ScriptableVariables.Core.InternalHelpers
{
#if UNITY_EDITOR
    [Serializable]
    internal class ReadWriteReferencesContainer : ReferencesContainerBase
    {
        Type _readerType;
        Type _writerType;
        
        [Header("Prefabs")]
        public List<Component> Readers;
        public List<Component> Writers;
            
        [Header("Scene")]
        public List<Component> readers;
        public List<Component> writers;
        
        public ReadWriteReferencesContainer(string fieldName, Type baseType, Type readerType, Type writerType) : base(fieldName, baseType)
        {
            _writerType = writerType;
            _readerType = readerType;
        }
        
        public override int TotalReferencesCount() => Writers.Count + Readers.Count + writers.Count + readers.Count;

        public override bool ListsAreNull() => Writers == null || Readers == null || writers == null || readers == null;

        public override void Clear()
        {
            Readers?.Clear();
            Writers?.Clear();
            readers?.Clear();
            writers?.Clear();
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

                bool isGetter = type == _readerType;
                bool isSetter = type == _writerType;

                if (!isGetter && !isSetter) continue;
                        
                object variableField = field.GetValue(component);
                if (variableField == null || (!_readerType.IsInstanceOfType(variableField) && !_writerType.IsInstanceOfType(variableField))) return;

                FieldInfo variableFieldInfo =
                    baseType.GetField(fieldName,
                        BindingFlags.Instance | BindingFlags.NonPublic);

                if (variableFieldInfo == null ||
                    !ReferenceEquals(variableFieldInfo.GetValue(variableField), variableCaller)) continue;

                switch (objectsToSearch)
                {
                    case ObjectsToSearch.Prefabs when isGetter:Readers?.Add(component); break;
                    case ObjectsToSearch.Prefabs: Writers?.Add(component); break;
                    case ObjectsToSearch.Scene when isGetter: readers?.Add(component); break;
                    case ObjectsToSearch.Scene: writers?.Add(component); break;
                }
            }
        }
    }
#endif
}
