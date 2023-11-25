using NuiN.ScriptableVariables.Base;

namespace NuiN.ScriptableVariables
{
    using UnityEngine; 
    using System.Collections.Generic;
    
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<float>", fileName = "New FloatList Variable")]
    public class FloatListSO : VariableSO<List<float>> { }
}