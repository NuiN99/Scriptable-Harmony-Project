using UnityEngine;
using System.Collections.Generic;
using NuiN.ScriptableVariables.Core.Variable.SOClasses.Base;

namespace NuiN.ScriptableVariables.Core.Variable.SOClasses
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<string>", fileName = "New StringList Variable")]
    internal class StringListSO : ScriptableVariableBaseSO<List<string>> { }
}