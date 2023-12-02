using UnityEngine;
using System.Collections.Generic;
using NuiN.ScriptableVariables.Core.Variable.SOClasses.Base;

namespace NuiN.ScriptableVariables.Core.Variable.SOClasses
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<double>", fileName = "New DoubleList Variable")]
    internal class DoubleListSO : ScriptableVariableBaseSO<List<double>> { }
}