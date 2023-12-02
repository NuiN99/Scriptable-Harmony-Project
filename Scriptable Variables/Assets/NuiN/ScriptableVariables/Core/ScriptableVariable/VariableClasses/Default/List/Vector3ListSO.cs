using UnityEngine;
using System.Collections.Generic;
using NuiN.ScriptableVariables.Core.Variable.SOClasses.Base;

namespace NuiN.ScriptableVariables.Core.Variable.SOClasses
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<Vector3>", fileName = "New Vector3List Variable")]
    internal class Vector3ListSO : ScriptableVariableBaseSO<List<Vector3>> { }
}