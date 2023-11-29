using UnityEngine;
using NuiN.ScriptableVariables.Core.Base;
using System.Collections.Generic;

namespace NuiN.ScriptableVariables.Types
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<long>", fileName = "New LongList Variable")]
    internal class LongListSO : ScriptableVariableBaseSO<List<long>> { }
}