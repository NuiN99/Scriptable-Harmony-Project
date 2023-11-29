using UnityEngine;
using NuiN.ScriptableVariables.Core.Base;
using System.Collections.Generic;

namespace NuiN.ScriptableVariables.Types
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<Vector2>", fileName = "New Vector2List Variable")]
    internal class Vector2ListSO : ScriptableVariableBaseSO<List<Vector2>> { }
}