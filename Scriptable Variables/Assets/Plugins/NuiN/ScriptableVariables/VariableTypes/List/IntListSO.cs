using NuiN.ScriptableVariables.Base;

namespace NuiN.ScriptableVariables
{
    using UnityEngine; 
    using System.Collections.Generic;
    
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<int>", fileName = "New IntList Variable")]
    internal class IntListSO : VariableSO<List<int>> { }
}