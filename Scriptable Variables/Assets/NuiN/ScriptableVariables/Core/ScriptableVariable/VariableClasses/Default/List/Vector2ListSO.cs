using UnityEngine;
using System.Collections.Generic;
using NuiN.ScriptableVariables.Core.Variable.SOClasses.Base;

namespace NuiN.ScriptableVariables.Core.Variable.SOClasses
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<Vector2>", fileName = "New Vector2List Variable")]
    internal class Vector2ListSO : ScriptableVariableBaseSO<List<Vector2>> { }
}