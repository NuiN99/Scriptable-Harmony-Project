using UnityEngine;
using NuiN.ScriptableVariables.Base;
using System.Collections.Generic;

namespace NuiN.ScriptableVariables.Types
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<Vector3>", fileName = "New Vector3List Variable")]
    internal class Vector3ListSO : VariableSO<List<Vector3>> { }
}