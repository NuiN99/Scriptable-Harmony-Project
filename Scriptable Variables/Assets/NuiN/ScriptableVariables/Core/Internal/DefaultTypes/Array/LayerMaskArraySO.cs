using UnityEngine;
using NuiN.ScriptableVariables.Core.Base;

namespace NuiN.ScriptableVariables.Types
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/Array/LayerMask[]", fileName = "New LayerMaskArray Variable")]
    internal class LayerMaskArraySO : ScriptableVariableBaseSO<LayerMask[]> { }
}