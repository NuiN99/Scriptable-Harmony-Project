using UnityEngine;
using NuiN.ScriptableVariables.Core.Base;
using System.Collections.Generic;

namespace NuiN.ScriptableVariables.Types
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<Vector3Int>", fileName = "New Vector3IntList Variable")]
    internal class Vector3IntListSO : ScriptableVariableBaseSO<List<Vector3Int>> { }
}