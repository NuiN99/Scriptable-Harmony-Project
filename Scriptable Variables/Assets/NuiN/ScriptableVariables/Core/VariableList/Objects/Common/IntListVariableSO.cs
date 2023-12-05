using UnityEngine;
using System.Collections.Generic;
using NuiN.ScriptableVariables.ListVariable.Base;

namespace NuiN.ScriptableVariables.ListVariable.Common
{   
    [CreateAssetMenu(
        menuName = "ScriptableVariables/Common/ListVariables/int", 
        fileName = "New Int ListVariable")]
    internal class IntListVariableSO : ScriptableListVariableBaseSO<int> { }
}