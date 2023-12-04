using NuiN.ScriptableVariables.Variable.Base;
using UnityEngine;

namespace NuiN.ScriptableVariables.Variable.Common
{   
    [CreateAssetMenu(
        menuName = "ScriptableVariables/Common/Variables/bool", 
        fileName = "New Bool Variable")]
    internal class BoolSO : ScriptableVariableBaseSO<bool> { }
}