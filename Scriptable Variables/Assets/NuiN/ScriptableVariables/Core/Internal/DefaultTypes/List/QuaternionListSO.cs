using UnityEngine;
using NuiN.ScriptableVariables.Core.Base;
using System.Collections.Generic;

namespace NuiN.ScriptableVariables.Types
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<Quaternion>", fileName = "New QuaternionList Variable")]
    internal class QuaternionListSO : ScriptableVariableBaseSO<List<Quaternion>> { }
}