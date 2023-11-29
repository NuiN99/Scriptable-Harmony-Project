using UnityEngine;
using NuiN.ScriptableVariables.Core.Base;
using System.Collections.Generic;

namespace NuiN.ScriptableVariables.Types
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<int>", fileName = "New IntList Variable")]
    internal class IntListSO : ScriptableVariableBaseSO<List<int>> { }
}