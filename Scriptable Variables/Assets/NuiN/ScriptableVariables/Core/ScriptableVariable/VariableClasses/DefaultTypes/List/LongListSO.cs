using UnityEngine;
using System.Collections.Generic;
using NuiN.ScriptableVariables.Core.ScriptableVariable.ScriptableObjectClasses.Base;

namespace NuiN.ScriptableVariables.Core.ScriptableVariable.ScriptableObjectClasses
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<long>", fileName = "New LongList Variable")]
    internal class LongListSO : ScriptableVariableBaseSO<List<long>> { }
}