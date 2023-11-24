using NuiN.ScriptableVariables.Base;

namespace NuiN.ScriptableVariables
{
    using UnityEngine; 
    using System.Collections.Generic;
    
    [CreateAssetMenu(menuName = "ScriptableObjects/Variables/List<int>", fileName = "New IntList Variable")]
    public class IntListSO : VariableSO<List<int>> { }
}