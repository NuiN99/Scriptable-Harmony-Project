using NuiN.ScriptableVariables.Base;

namespace NuiN.ScriptableVariables
{
    using UnityEngine; 
    using System.Collections.Generic;
    
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<double>", fileName = "New DoubleList Variable")]
    internal class DoubleListSO : VariableSO<List<double>> { }
}