using NuiN.ScriptableVariables.Variable.Base;
using UnityEngine;

namespace NuiN.ScriptableVariables.Variable.Common
{   
    [CreateAssetMenu(
        menuName = "ScriptableVariables/Common/Variables/float", 
        fileName = "New Float Variable")]
    internal class FloatVariableSO : ScriptableVariableBaseSO<float> { }
}