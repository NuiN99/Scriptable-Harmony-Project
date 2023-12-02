using UnityEngine;
using System.Collections.Generic;
using NuiN.ScriptableVariables.Core.Variable.SOClasses.Base;

namespace NuiN.ScriptableVariables.Core.Variable.SOClasses
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<int>", fileName = "New IntList Variable")]
    internal class IntListSO : ScriptableVariableBaseSO<List<int>> { }
}