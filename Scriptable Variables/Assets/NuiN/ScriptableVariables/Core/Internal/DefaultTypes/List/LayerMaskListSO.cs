using UnityEngine;
using NuiN.ScriptableVariables.Core.Base;
using System.Collections.Generic;

namespace NuiN.ScriptableVariables.Types
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<LayerMask>", fileName = "New LayerMaskList Variable")]
    internal class LayerMaskListSO : ScriptableVariableBaseSO<List<LayerMask>> { }
}