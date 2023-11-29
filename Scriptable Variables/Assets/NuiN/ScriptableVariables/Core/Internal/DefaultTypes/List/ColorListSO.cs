using UnityEngine;
using NuiN.ScriptableVariables.Core.Base;
using System.Collections.Generic;

namespace NuiN.ScriptableVariables.Types
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<Color>", fileName = "New ColorList Variable")]
    internal class ColorListSO : ScriptableVariableBaseSO<List<Color>> { }
}