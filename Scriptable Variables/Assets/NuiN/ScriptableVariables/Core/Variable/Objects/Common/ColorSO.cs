using NuiN.ScriptableVariables.Variable.Base;
using UnityEngine;

namespace NuiN.ScriptableVariables.Variable.Common
{   
    [CreateAssetMenu(
        menuName = "ScriptableVariables/Common/Variables/Color", 
        fileName = "New Color Variable")]
    internal class ColorVariableSO : ScriptableVariableBaseSO<Color> { }
}