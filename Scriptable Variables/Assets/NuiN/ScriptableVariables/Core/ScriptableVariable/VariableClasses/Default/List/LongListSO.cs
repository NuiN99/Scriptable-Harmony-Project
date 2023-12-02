using UnityEngine;
using System.Collections.Generic;
using NuiN.ScriptableVariables.Core.Variable.SOClasses.Base;

namespace NuiN.ScriptableVariables.Core.Variable.SOClasses
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<long>", fileName = "New LongList Variable")]
    internal class LongListSO : ScriptableVariableBaseSO<List<long>> { }
}