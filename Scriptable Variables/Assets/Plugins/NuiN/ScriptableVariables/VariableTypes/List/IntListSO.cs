using UnityEngine;
using NuiN.ScriptableVariables.Base;
using System.Collections.Generic;

namespace NuiN.ScriptableVariables.Types
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<int>", fileName = "New IntList Variable")]
    internal class IntListSO : VariableSO<List<int>> { }
}