using NuiN.ScriptableVariables.Base;

namespace NuiN.ScriptableVariables
{
    using UnityEngine; 
    using System.Collections.Generic;
    
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<bool>", fileName = "New BoolList Variable")]
    internal class BoolListSO : VariableSO<List<bool>> { }
}