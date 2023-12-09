using UnityEngine;
using NuiN.ScriptableHarmony.ListVariable.Base;

namespace NuiN.ScriptableHarmony.ListVariable.Common
{   
    [CreateAssetMenu(
        menuName = "ScriptableHarmony/Common/ListVariables/Bool",
        fileName = "New Bool ListVariable")]
    internal class BoolListVariableSO : ScriptableListVariableBaseSO<bool> { }
}