using NuiN.ScriptableVariables.Base;

namespace NuiN.ScriptableVariables
{
    using UnityEngine; 
    using System.Collections.Generic;
    
    [CreateAssetMenu(menuName = "ScriptableObjects/Variables/List<bool>", fileName = "New BoolList Variable")]
    public class BoolListSO : VariableSO<List<bool>> { }
}