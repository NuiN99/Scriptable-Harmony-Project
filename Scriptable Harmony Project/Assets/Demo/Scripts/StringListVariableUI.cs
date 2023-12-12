using System;
using System.Collections;
using System.Collections.Generic;
using NuiN.ScriptableHarmony.References;
using UnityEngine;
using UnityEngine.UI;

public class StringListVariableUI : MonoBehaviour
{
    Dictionary<int, Text> _listObjects = new();
    
    [SerializeField] Text listItemPrefab;
    [SerializeField] GetListVariable<string> stringList;

    void OnEnable()
    {
        stringList.SubOnAdd(CreateListItem);
        stringList.SubOnRemoveWithOld(RemoveItem);
    }
    void OnDisable()
    {
        stringList.UnSubOnAdd(CreateListItem);
        stringList.SubOnRemoveWithOld(RemoveItem);
    }

    void CreateListItem(string text)
    {
        Text newListItem = Instantiate(listItemPrefab, transform);
        newListItem.text = text;

        int id = stringList.Items.Count - 1;
        if (!_listObjects.TryAdd(id, newListItem))
        {
            Destroy(newListItem.gameObject);
        }
    }
    void RemoveItem(List<string> prev, string text)
    {
        for (int i = prev.Count - 1; i >= 0; i--)
        {
            if (prev[i] != text || !_listObjects.TryGetValue(i, out Text listItem)) continue;
            
            Destroy(listItem.gameObject);
            _listObjects.Remove(i);
            prev.RemoveAt(i);
        }
    }

}
