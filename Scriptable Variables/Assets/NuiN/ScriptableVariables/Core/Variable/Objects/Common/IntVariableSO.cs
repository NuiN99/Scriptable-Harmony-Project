using NuiN.ScriptableVariables.Variable.Base;
using UnityEngine;

namespace NuiN.ScriptableVariables.Variable.Common
{   
    [CreateAssetMenu(
        menuName = "ScriptableVariables/Common/Variables/int", 
        fileName = "New Int Variable")]
    internal class IntVariableSO : ScriptableVariableBaseSO<int> { }
}