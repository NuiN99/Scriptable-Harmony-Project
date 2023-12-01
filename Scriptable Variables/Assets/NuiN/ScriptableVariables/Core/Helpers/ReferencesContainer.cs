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
    internal class ReferencesContainer<TB>
    {
        Type _getterType;
        Type _setterType;
        string _fieldName;
        
        [Header("Prefabs")]
        // ReSharper disable once InconsistentNaming
        public List<Component> Setters;
        // ReSharper disable once InconsistentNaming
        public List<Component> Getters;
            
        [Header("Scene")]
        public List<Component> setters;
        public List<Component> getters;
            
        public int TotalReferencesCount => Setters.Count + Getters.Count + setters.Count + getters.Count;

        public bool ListsAreNull => Setters == null || Getters == null || setters == null || getters == null;

        public ReferencesContainer(Type getterType, Type setterType, string fieldName)
        {
            _getterType = getterType;
            _setterType = setterType;
            _fieldName = fieldName;
        }

        public void Clear()
        {
            Getters?.Clear();
            Setters?.Clear();
            getters?.Clear();
            setters?.Clear();
        }
        
        public void FindObjectsAndAssignReferences(object variableCaller, IEnumerable<GameObject> sceneObjs, out int count)
        {
            Clear();
                
            string[] guids = AssetDatabase.FindAssets( "t:Prefab" );
            GameObject[] allPrefabs = guids.Select(guid =>
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                return AssetDatabase.LoadAssetAtPath<GameObject>(path);
            }).ToArray();

            AssignReferences(variableCaller, allPrefabs, true);
            AssignReferences(variableCaller, sceneObjs, false);
            
            count = ListsAreNull ? 0 : TotalReferencesCount;
        }
        
        void AssignReferences(object variableCaller, IEnumerable<GameObject> foundObjects, bool prefabs)
        {
            foreach (var obj in foundObjects)
            {
                Component[] components =
                    prefabs ? obj.GetComponentsInChildren<Component>() : obj.GetComponents<Component>();

                foreach (var component in components)
                {
                    if (!component) continue;

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

                        if (field.GetValue(component) is not TB variableField) continue;

                        FieldInfo variableFieldInfo =
                            typeof(TB).GetField(_fieldName,
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
        }
    }
#endif
}
