using UnityEngine;
using System.Collections.Generic;
using NuiN.ScriptableVariables.Core.ScriptableVariable.ScriptableObjectClasses.Base;

namespace NuiN.ScriptableVariables.Core.ScriptableVariable.ScriptableObjectClasses
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<Vector3>", fileName = "New Vector3List Variable")]
    internal class Vector3ListSO : ScriptableVariableBaseSO<List<Vector3>> { }
}