using UnityEngine;
using NuiN.ScriptableVariables.Core.Base;
using System.Collections.Generic;

namespace NuiN.ScriptableVariables.Types
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<bool>", fileName = "New BoolList Variable")]
    internal class BoolListSO : ScriptableVariableBaseSO<List<bool>> { }
}