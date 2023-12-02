using UnityEngine;
using System.Collections.Generic;
using NuiN.ScriptableVariables.Core.Variable.SOClasses.Base;

namespace NuiN.ScriptableVariables.Core.Variable.SOClasses
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<bool>", fileName = "New BoolList Variable")]
    internal class BoolListSO : ScriptableVariableBaseSO<List<bool>> { }
}