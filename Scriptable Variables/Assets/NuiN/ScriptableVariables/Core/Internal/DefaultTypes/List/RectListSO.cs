using UnityEngine;
using NuiN.ScriptableVariables.Core.Base;
using System.Collections.Generic;

namespace NuiN.ScriptableVariables.Types
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<Rect>", fileName = "New RectList Variable")]
    internal class RectListSO : ScriptableVariableBaseSO<List<Rect>> { }
}