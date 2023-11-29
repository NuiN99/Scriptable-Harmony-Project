using UnityEngine;
using NuiN.ScriptableVariables.Core.Base;
using System.Collections.Generic;

namespace NuiN.ScriptableVariables.Types
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<double>", fileName = "New DoubleList Variable")]
    internal class DoubleListSO : ScriptableVariableBaseSO<List<double>> { }
}