using NuiN.ScriptableVariables.Variable.Base;
using UnityEngine;

namespace NuiN.ScriptableVariables.Variable.Common
{   
    [CreateAssetMenu(
        menuName = "ScriptableVariables/Common/Variables/Material", 
        fileName = "New Material Variable")]
    internal class MaterialSO : ScriptableVariableBaseSO<Material> { }
}