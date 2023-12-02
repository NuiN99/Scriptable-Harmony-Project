using UnityEngine;
using System.Collections.Generic;
using NuiN.ScriptableVariables.Core.ScriptableVariable.ScriptableObjectClasses.Base;

namespace NuiN.ScriptableVariables.Core.ScriptableVariable.ScriptableObjectClasses
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<Vector2Int>", fileName = "New Vector2IntList Variable")]
    internal class Vector2IntListSO : ScriptableVariableBaseSO<List<Vector2Int>> { }
}