using UnityEngine;
using NuiN.ScriptableVariables.Base;
using System.Collections.Generic;

namespace NuiN.ScriptableVariables.Types
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<bool>", fileName = "New BoolList Variable")]
    internal class BoolListSO : VariableSO<List<bool>> { }
}