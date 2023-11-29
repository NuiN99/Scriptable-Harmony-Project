using UnityEngine;
using NuiN.ScriptableVariables.Core.Base;
using System.Collections.Generic;

namespace NuiN.ScriptableVariables.Types
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<Vector4>", fileName = "New Vector4List Variable")]
    internal class Vector4ListSO : ScriptableVariableBaseSO<List<Vector4>> { }
}