using NuiN.ScriptableVariables.Base;

namespace NuiN.ScriptableVariables
{
    using UnityEngine; 
    using System.Collections.Generic;
    
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<string>", fileName = "New StringList Variable")]
    internal class StringListSO : VariableSO<List<string>> { }
}