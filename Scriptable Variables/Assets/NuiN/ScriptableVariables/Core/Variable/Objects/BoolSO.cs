using NuiN.ScriptableVariables.Core.Variable.Base;
using UnityEngine;

namespace NuiN.ScriptableVariables.Core.Variable.SOClasses
{   
    [CreateAssetMenu(
        menuName = "ScriptableVariables/Common/Variables/bool", 
        fileName = "New Bool Variable")]
    internal class BoolSO : ScriptableVariableBaseSO<bool> { }
}