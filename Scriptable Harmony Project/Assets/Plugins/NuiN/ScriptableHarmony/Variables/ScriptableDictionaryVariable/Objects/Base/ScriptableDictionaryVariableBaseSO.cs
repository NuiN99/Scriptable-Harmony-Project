using System;
using System.Collections.Generic;
using NuiN.ScriptableHarmony.Base;
using NuiN.ScriptableHarmony.Editor.Attributes;
using NuiN.ScriptableHarmony.Internal.Helpers;
using NuiN.ScriptableHarmony.ListVariable.References.Base;
using NuiN.ScriptableHarmony.References;
using UnityEditor;
using UnityEngine;

namespace NuiN.ScriptableHarmony.ListVariable.Base
{
    public class ScriptableDictionaryVariableBaseSO<TKey,TValue> : ScriptableVariableLifetimeBaseSO<TKey>
    {
        public Dictionary<TKey,TValue> dictionary = new();
        [ReadOnlyPlayMode] Dictionary<TKey,TValue> defaultDictionary = new();

        public SerializableDictionary<TKey, TValue> serializedDictionary;
        
        [Header("Value Persistence")]
        [SerializeField] bool resetOnSceneLoad = true;

        [Header("Debugging")] 
        [SerializeField] bool logActions = true;
        [SerializeField] GetSetReferencesContainer gettersAndSetters = new("list", typeof(ReferenceScriptableDictionaryVariableBase<TKey,TValue>), typeof(GetDictionaryVariable<TKey,TValue>), typeof(SetDictionaryVariable<TKey,TValue>));
        protected override GetSetReferencesContainer GettersAndSetters { get => gettersAndSetters;set => gettersAndSetters = value; }
        
        public Dictionary<TKey,TValue> DefaultValues => defaultDictionary;
        public override bool LogActions => logActions;
        
        void OnValidate()
        {
            if(!Application.isPlaying) SaveDefaultValue();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            serializedDictionary ??= new SerializableDictionary<TKey, TValue>(ref dictionary);
            serializedDictionary._dictionary = dictionary;
            serializedDictionary.ValidateAndApply();
            Debug.Log(dictionary.Count);
        }

        [SOMethodButton("ValidateDictionary", true)]
        public void ValidateDictionary()
        {
            Undo.RecordObject(this, "Validate and Apply");
            serializedDictionary.ValidateAndApply();
            EditorUtility.SetDirty(this);
            Debug.Log(dictionary.Count);
        }

        protected override void SaveDefaultValue() => defaultDictionary = new Dictionary<TKey,TValue>(dictionary);
        protected override void ResetValueToDefault()
        {
            SetDictionaryVariable<TKey,TValue> dictionaryVar = new(this);
            dictionaryVar.ResetDictionary();
            serializedDictionary.Serialize();
        }

        protected override bool ResetsOnSceneLoad() => resetOnSceneLoad;
    }
}
