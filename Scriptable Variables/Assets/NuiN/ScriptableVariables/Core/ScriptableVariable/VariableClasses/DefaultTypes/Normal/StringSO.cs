using UnityEngine;
using NuiN.ScriptableVariables.Core.ScriptableVariable.ScriptableObjectClasses.Base;

namespace NuiN.ScriptableVariables.Core.ScriptableVariable.ScriptableObjectClasses
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/Normal/string", fileName = "New String Variable")]
    internal class StringSO : ScriptableVariableBaseSO<string> { }
}