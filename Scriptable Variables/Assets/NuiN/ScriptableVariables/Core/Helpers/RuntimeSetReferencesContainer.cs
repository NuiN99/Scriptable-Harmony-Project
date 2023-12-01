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
    internal class RuntimeSetReferencesContainer
    {
        string _fieldName;

        public List<Component> prefabItems;
        public List<Component> sceneItems;

        public int TotalReferencesCount => prefabItems.Count + sceneItems.Count;

        public bool ListsAreNull => prefabItems == null || sceneItems == null;

        Type _baseType;
        Type _writerType;

        public RuntimeSetReferencesContainer(string fieldName, Type writerType, Type baseType)
        {
            _writerType = writerType;
            _baseType = baseType;
            _fieldName = fieldName;
        }

        public void Clear()
        {
            prefabItems?.Clear();
            sceneItems?.Clear();
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
                    Type baseType = componentType.BaseType;
                    if (baseType == null || baseType != _baseType) continue;
                    
                    FieldInfo[] fields = baseType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                    foreach (var field in fields)
                    {
                        Type type = field.FieldType;
                        if (!type.IsGenericType) continue;

                        object variableField = field.GetValue(component);
                        if (!(variableField != null && _writerType.IsInstanceOfType(variableField))) continue;

                        FieldInfo variableFieldInfo =
                            _writerType.GetField(_fieldName,
                                BindingFlags.Instance | BindingFlags.NonPublic);

                        if (variableFieldInfo == null ||
                            !ReferenceEquals(variableFieldInfo.GetValue(variableField), variableCaller)) continue;

                        if (prefabs)
                        {
                            prefabItems.Add(component);
                        }
                        else
                        {
                            sceneItems.Add(component);
                        }
                    }
                }
            }
        }
    }
#endif
}
