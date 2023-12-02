using UnityEngine;
using System.Collections.Generic;
using NuiN.ScriptableVariables.Core.ScriptableVariable.ScriptableObjectClasses.Base;

namespace NuiN.ScriptableVariables.Core.ScriptableVariable.ScriptableObjectClasses
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<Vector2>", fileName = "New Vector2List Variable")]
    internal class Vector2ListSO : ScriptableVariableBaseSO<List<Vector2>> { }
}