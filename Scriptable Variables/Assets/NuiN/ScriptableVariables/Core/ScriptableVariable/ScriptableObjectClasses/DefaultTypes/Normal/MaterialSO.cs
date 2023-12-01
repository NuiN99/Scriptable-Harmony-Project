using UnityEngine;
using NuiN.ScriptableVariables.Core.Base;

namespace NuiN.ScriptableVariables.Types
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/Normal/Material", fileName = "New Material Variable")]
    internal class MaterialSO : ScriptableVariableBaseSO<Material> { }
}