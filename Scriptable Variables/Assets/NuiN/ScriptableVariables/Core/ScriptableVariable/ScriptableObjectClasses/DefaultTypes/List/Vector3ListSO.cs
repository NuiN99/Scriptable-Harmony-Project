using UnityEngine;
using NuiN.ScriptableVariables.Core.Base;
using System.Collections.Generic;

namespace NuiN.ScriptableVariables.Types
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<Vector3>", fileName = "New Vector3List Variable")]
    internal class Vector3ListSO : ScriptableVariableBaseSO<List<Vector3>> { }
}