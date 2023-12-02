using UnityEngine;
using NuiN.ScriptableVariables.Core.ScriptableVariable.ScriptableObjectClasses.Base;

namespace NuiN.ScriptableVariables.Core.ScriptableVariable.ScriptableObjectClasses
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/Normal/Color", fileName = "New Color Variable")]
    internal class ColorSO : ScriptableVariableBaseSO<Color> { }
}