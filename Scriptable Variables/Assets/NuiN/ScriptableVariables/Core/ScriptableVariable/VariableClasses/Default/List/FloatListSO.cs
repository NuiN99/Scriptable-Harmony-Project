using UnityEngine;
using System.Collections.Generic;
using NuiN.ScriptableVariables.Core.Variable.SOClasses.Base;

namespace NuiN.ScriptableVariables.Core.Variable.SOClasses
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<float>", fileName = "New FloatList Variable")]
    internal class FloatListSO : ScriptableVariableBaseSO<List<float>> { }
}