using UnityEngine;
using System.Collections.Generic;
using NuiN.ScriptableVariables.Core.ScriptableVariable.ScriptableObjectClasses.Base;

namespace NuiN.ScriptableVariables.Core.ScriptableVariable.ScriptableObjectClasses
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<Vector3Int>", fileName = "New Vector3IntList Variable")]
    internal class Vector3IntListSO : ScriptableVariableBaseSO<List<Vector3Int>> { }
}