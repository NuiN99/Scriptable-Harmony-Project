using NuiN.ScriptableVariables.Base;

namespace NuiN.ScriptableVariables
{
    using UnityEngine; 
    using System.Collections.Generic;
    
    [CreateAssetMenu(menuName = "ScriptableObjects/Variables/List<string>", fileName = "New StringList Variable")]
    public class StringListSO : VariableSO<List<string>> { }
}