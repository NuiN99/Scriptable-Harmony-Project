using UnityEngine;
using NuiN.ScriptableVariables.Core.Base;

namespace NuiN.ScriptableVariables.Types
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/Array/string[]", fileName = "New StringArray Variable")]
    internal class StringArraySO : ScriptableVariableBaseSO<string[]> { }
}