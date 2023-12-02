using UnityEngine;
using System.Collections.Generic;
using NuiN.ScriptableVariables.Core.Variable.SOClasses.Base;

namespace NuiN.ScriptableVariables.Core.Variable.SOClasses
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<Vector3Int>", fileName = "New Vector3IntList Variable")]
    internal class Vector3IntListSO : ScriptableVariableBaseSO<List<Vector3Int>> { }
}