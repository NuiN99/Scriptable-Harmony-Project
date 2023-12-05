using UnityEngine;
using NuiN.ScriptableVariables.ListVariable.Base;

namespace NuiN.ScriptableVariables.ListVariable.Common
{   
    [CreateAssetMenu(
        menuName = "ScriptableVariables/Common/ListVariables/float",
        fileName = "New Float ListVariable")]
    internal class FloatListVariableSO : ScriptableListVariableBaseSO<float> { }
}