using UnityEngine;
using NuiN.ScriptableVariables.Core.ScriptableVariable.ScriptableObjectClasses.Base;

namespace NuiN.ScriptableVariables.Core.ScriptableVariable.ScriptableObjectClasses
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/Normal/bool", fileName = "New Bool Variable")]
    internal class BoolSO : ScriptableVariableBaseSO<bool> { }
}