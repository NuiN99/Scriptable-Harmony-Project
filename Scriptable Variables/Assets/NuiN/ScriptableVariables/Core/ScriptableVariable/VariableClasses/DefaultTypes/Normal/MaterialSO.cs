using UnityEngine;
using NuiN.ScriptableVariables.Core.ScriptableVariable.ScriptableObjectClasses.Base;

namespace NuiN.ScriptableVariables.Core.ScriptableVariable.ScriptableObjectClasses
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/Normal/Material", fileName = "New Material Variable")]
    internal class MaterialSO : ScriptableVariableBaseSO<Material> { }
}