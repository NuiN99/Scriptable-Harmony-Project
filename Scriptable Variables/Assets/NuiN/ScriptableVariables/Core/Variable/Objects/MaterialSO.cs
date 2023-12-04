using NuiN.ScriptableVariables.Core.Variable.Base;
using UnityEngine;

namespace NuiN.ScriptableVariables.Core.Variable.SOClasses
{   
    [CreateAssetMenu(
        menuName = "ScriptableVariables/Common/Variables/Material", 
        fileName = "New Material Variable")]
    internal class MaterialSO : ScriptableVariableBaseSO<Material> { }
}