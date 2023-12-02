using UnityEngine;
using System.Collections.Generic;
using NuiN.ScriptableVariables.Core.Variable.SOClasses.Base;

namespace NuiN.ScriptableVariables.Core.Variable.SOClasses
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<Material>", fileName = "New MaterialList Variable")]
    internal class MaterialListSO : ScriptableVariableBaseSO<List<Material>> { }
}