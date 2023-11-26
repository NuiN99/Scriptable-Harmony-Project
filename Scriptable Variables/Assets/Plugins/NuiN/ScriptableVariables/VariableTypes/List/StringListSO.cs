using UnityEngine;
using NuiN.ScriptableVariables.Base;
using System.Collections.Generic;

namespace NuiN.ScriptableVariables.Types
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<string>", fileName = "New StringList Variable")]
    internal class StringListSO : VariableSO<List<string>> { }
}