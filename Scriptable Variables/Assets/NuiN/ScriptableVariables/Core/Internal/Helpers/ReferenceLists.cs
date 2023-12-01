using System;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
[Serializable]
internal class ReferenceLists
{
    [Header("Prefabs")]
    public List<Component> Setters;
    public List<Component> Getters;
        
    [Header("Scene")]
    public List<Component> setters;
    public List<Component> getters;
        
    public int TotalReferencesCount => Setters.Count + Getters.Count + setters.Count + getters.Count;

    public bool ListsAreNull => Setters == null || Getters == null || setters == null || getters == null;

    public void Clear()
    {
        Getters?.Clear();
        Setters?.Clear();
        getters?.Clear();
        setters?.Clear();
    }
}
#endif