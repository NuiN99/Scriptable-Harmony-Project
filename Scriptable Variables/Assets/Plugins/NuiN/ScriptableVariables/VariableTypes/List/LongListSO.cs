using NuiN.ScriptableVariables.Base;

namespace NuiN.ScriptableVariables
{
    using UnityEngine; 
    using System.Collections.Generic;
    
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<long>", fileName = "New LongList Variable")]
    public class LongListSO : VariableSO<List<long>> { }
}