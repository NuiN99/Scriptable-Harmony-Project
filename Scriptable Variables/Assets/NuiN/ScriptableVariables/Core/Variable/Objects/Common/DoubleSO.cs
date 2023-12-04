using NuiN.ScriptableVariables.Variable.Base;
using UnityEngine;

namespace NuiN.ScriptableVariables.Variable.Common
{   
    [CreateAssetMenu(
        menuName = "ScriptableVariables/Common/Variables/double", 
        fileName = "New Double Variable")]
    internal class DoubleSO : ScriptableVariableBaseSO<double> { }
}