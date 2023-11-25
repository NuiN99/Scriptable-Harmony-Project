using NuiN.ScriptableVariables.Base;

namespace NuiN.ScriptableVariables
{
    using UnityEngine; 
    
    [CreateAssetMenu(menuName = "ScriptableVariables/Array/string[]", fileName = "New StringArray Variable")]
    internal class StringArraySO : VariableSO<string[]> { }
}