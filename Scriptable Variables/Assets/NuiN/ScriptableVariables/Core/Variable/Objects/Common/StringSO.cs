using NuiN.ScriptableVariables.Variable.Base;
using UnityEngine;

namespace NuiN.ScriptableVariables.Variable.Common
{   
    [CreateAssetMenu(
        menuName = "ScriptableVariables/Common/Variables/string", 
        fileName = "New String Variable")]
    internal class StringVariableSO : ScriptableVariableBaseSO<string> { }
}