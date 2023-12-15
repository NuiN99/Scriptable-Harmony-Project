using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public class SerializableDictionary<TKey,TValue>
{
   Dictionary<TKey, TValue> _dictionary;
   [SerializeField] List<SerializedKeyValuePair<TKey, TValue>> keyValuePairs = new();

   public SerializableDictionary(Dictionary<TKey, TValue> dictionary)
   {
      _dictionary = dictionary;
   }
   
   public void Add(TKey key, TValue value)
   {
      keyValuePairs.Add(new SerializedKeyValuePair<TKey, TValue>(key, value));
   }
   public void Serialize()
   {
      keyValuePairs.Clear();
      foreach (KeyValuePair<TKey, TValue> item in _dictionary)
      {
         Add(item.Key, item.Value);
      }
      
   }
   
   public void ValidateAndApply()
   {
      _dictionary.Clear();
      List<SerializedKeyValuePair<TKey, TValue>> duplicates = new();
      foreach (var pair in keyValuePairs)
      {
         bool success = _dictionary.TryAdd(pair.key, pair.value);
         if(!success) duplicates.Add(pair);
      }

      foreach (var duplicate in duplicates)
      {
         Debug.LogWarning($"Validation: Removed duplicate | Key: {duplicate.key} | Value: {duplicate.value}");
         keyValuePairs.Remove(duplicate);
      }
      
      Serialize();
   }
}
