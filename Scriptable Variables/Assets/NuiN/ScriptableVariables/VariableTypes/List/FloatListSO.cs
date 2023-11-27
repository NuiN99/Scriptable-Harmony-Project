using UnityEngine;
using NuiN.ScriptableVariables.Base;
using System.Collections.Generic;

namespace NuiN.ScriptableVariables.Types
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<float>", fileName = "New FloatList Variable")]
    internal class FloatListSO : VariableSO<List<float>> { }
}