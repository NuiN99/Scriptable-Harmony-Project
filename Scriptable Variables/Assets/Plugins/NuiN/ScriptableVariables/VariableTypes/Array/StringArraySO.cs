using UnityEngine;
using NuiN.ScriptableVariables.Base;

namespace NuiN.ScriptableVariables.Types
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/Array/string[]", fileName = "New StringArray Variable")]
    internal class StringArraySO : VariableSO<string[]> { }
}