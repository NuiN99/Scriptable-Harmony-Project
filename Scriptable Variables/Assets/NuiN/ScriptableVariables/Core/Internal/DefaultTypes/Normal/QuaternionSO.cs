using UnityEngine;
using NuiN.ScriptableVariables.Core.Base;

namespace NuiN.ScriptableVariables.Types
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/Normal/Quaternion", fileName = "New Quaternion Variable")]
    internal class QuaternionSO : ScriptableVariableBaseSO<Quaternion> { }
}