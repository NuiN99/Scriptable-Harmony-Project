namespace NuiN.ScriptableVariables
{
    using UnityEngine;
    using NuiN.ScriptableVariables.Base;
    
    [CreateAssetMenu(menuName = "ScriptableObjects/Variables/Color[]", fileName = "New ColorArray Variable")]
    public class ColorArraySO : VariableSO<Color[]> { }
}