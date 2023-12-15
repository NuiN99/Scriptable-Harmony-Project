using System;
using System.Collections.Generic;
using System.Diagnostics;
using NuiN.ScriptableHarmony.Internal.Helpers;
using NuiN.ScriptableHarmony.Internal.Logging;
using NuiN.ScriptableHarmony.ListVariable.Base;
using NuiN.ScriptableHarmony.ListVariable.References.Base;
using UnityEditor;

namespace NuiN.ScriptableHarmony.References
{
    [Serializable]
    public class SetDictionaryVariable<T,TU> : ReferenceScriptableDictionaryVariableBase<T,TU>
    {
        public Dictionary<T,TU> Dictionary => dictionaryVariable.dictionary;

        internal SetDictionaryVariable(ScriptableDictionaryVariableBaseSO<T,TU> variable)
        {
            dictionaryVariable = variable;
        }

        public void ResetDictionary()
        {
            
        }

        [Conditional("UNITY_EDITOR")]
        void SetDirty()
        {
#if UNITY_EDITOR
            EditorUtility.SetDirty(dictionaryVariable);
#endif
        }
    }
}
