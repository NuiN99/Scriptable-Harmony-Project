using UnityEngine;
using NuiN.ScriptableVariables.Core.Base;
using System.Collections.Generic;

namespace NuiN.ScriptableVariables.Types
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<Bounds>", fileName = "New BoundsList Variable")]
    internal class BoundsListSO : ScriptableVariableBaseSO<List<Bounds>> { }
}