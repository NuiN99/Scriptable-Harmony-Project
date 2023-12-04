using NuiN.ScriptableVariables.Core.Variable.Base;
using UnityEngine;

namespace NuiN.ScriptableVariables.Core.Variable.SOClasses
{   
    [CreateAssetMenu(
        menuName = "ScriptableVariables/Common/Variables/string", 
        fileName = "New String Variable")]
    internal class StringSO : ScriptableVariableBaseSO<string> { }
}