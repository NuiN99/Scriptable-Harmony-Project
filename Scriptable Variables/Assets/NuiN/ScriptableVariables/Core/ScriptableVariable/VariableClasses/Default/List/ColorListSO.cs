using UnityEngine;
using System.Collections.Generic;
using NuiN.ScriptableVariables.Core.Variable.SOClasses.Base;

namespace NuiN.ScriptableVariables.Core.Variable.SOClasses
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<Color>", fileName = "New ColorList Variable")]
    internal class ColorListSO : ScriptableVariableBaseSO<List<Color>> { }
}