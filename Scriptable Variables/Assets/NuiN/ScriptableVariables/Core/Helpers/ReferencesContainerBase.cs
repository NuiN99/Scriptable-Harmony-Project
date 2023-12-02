using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace NuiN.ScriptableVariables.Core.Helpers
{
    [Serializable]
    public abstract class ReferencesContainerBase
    {
        protected Type baseType;
        protected string fieldName;

        public abstract void Clear();
        public abstract int TotalReferencesCount();
        public abstract bool ListsAreNull();

        protected ReferencesContainerBase(string fieldName, Type baseType)
        {
            this.fieldName = fieldName;
            this.baseType = baseType;
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
            
            count = ListsAreNull() ? 0 : TotalReferencesCount();
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
                    CheckComponentAndAssign(variableCaller, component, prefabs);
                }
            }
        }
        
        public abstract void CheckComponentAndAssign(object variableCaller, Component component, bool prefabs);
    }
}