using NuiN.ScriptableVariables.Base;

namespace NuiN.ScriptableVariables
{
    using UnityEngine; 
    using System.Collections.Generic;
    
    [CreateAssetMenu(menuName = "ScriptableObjects/Variables/List<double>", fileName = "New DoubleList Variable")]
    public class DoubleListSO : VariableSO<List<double>> { }
}