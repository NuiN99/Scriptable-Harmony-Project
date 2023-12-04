using NuiN.ScriptableVariables.Core.Variable.Base;
using UnityEngine;

namespace NuiN.ScriptableVariables.Core.Variable.SOClasses
{   
    [CreateAssetMenu(
        menuName = "ScriptableVariables/Common/Variables/Color", 
        fileName = "New Color Variable")]
    internal class ColorSO : ScriptableVariableBaseSO<Color> { }
}