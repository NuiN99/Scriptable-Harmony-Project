using UnityEngine;
using NuiN.ScriptableVariables.Core.Base;
using System.Collections.Generic;

namespace NuiN.ScriptableVariables.Types
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<Material>", fileName = "New MaterialList Variable")]
    internal class MaterialListSO : ScriptableVariableBaseSO<List<Material>> { }
}