using UnityEngine;
using NuiN.ScriptableVariables.Base;

namespace NuiN.ScriptableVariables.Types
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/Normal/LayerMask", fileName = "New LayerMask Variable")]
    internal class LayerMaskSO : VariableSO<LayerMask> { }
}