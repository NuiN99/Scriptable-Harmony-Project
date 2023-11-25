namespace NuiN.ScriptableVariables
{
    using UnityEngine;
    using NuiN.ScriptableVariables.Base;
    
    [CreateAssetMenu(menuName = "ScriptableVariables/Array/Color[]", fileName = "New ColorArray Variable")]
    public class ColorArraySO : VariableSO<Color[]> { }
}