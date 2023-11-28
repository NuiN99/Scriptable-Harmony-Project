using UnityEngine;
using NuiN.ScriptableVariables.Base;
using System.Collections.Generic;

namespace NuiN.ScriptableVariables.Types
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<double>", fileName = "New DoubleList Variable")]
    internal class DoubleListSO : VariableSO<List<double>> { }
}