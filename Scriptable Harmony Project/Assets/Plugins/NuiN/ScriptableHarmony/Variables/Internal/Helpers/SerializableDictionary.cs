using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public class SerializableDictionary<TKey,TValue>
{
   [NonSerialized] public Dictionary<TKey, TValue> dictionary;
   [SerializeField] List<SerializedKeyValuePair<TKey, TValue>> serializedPairs = new();

   public SerializableDictionary(ref Dictionary<TKey, TValue> dictionary)
   {
      this.dictionary = dictionary;
   }
   
   public void Add(TKey key, TValue value)
   {
      serializedPairs.Add(new SerializedKeyValuePair<TKey, TValue>(key, value));
   }
   public void Serialize(ref Dictionary<TKey, TValue> newDict)
   {
      dictionary = newDict;
      serializedPairs?.Clear();
      foreach (KeyValuePair<TKey, TValue> item in dictionary)
      {
         Add(item.Key, item.Value);
      }
   }
   
   public void ValidateAndApply(ref Dictionary<TKey, TValue> newDict)
   {
      dictionary = newDict;
      
      dictionary.Clear();
      List<SerializedKeyValuePair<TKey, TValue>> duplicates = new();
      foreach (var pair in serializedPairs)
      {
         bool success = dictionary.TryAdd(pair.key, pair.value);
         if(!success) duplicates.Add(pair);
      }

      foreach (var duplicate in duplicates)
      {
         Debug.LogWarning($"Dictionary Validation: Removed duplicate | Key: {duplicate.key} | Value: {duplicate.value}");
         serializedPairs.Remove(duplicate);
      }
      Debug.Log($"Dictionary Validation: Successfully validated");
      Serialize(ref dictionary);
   }
}
