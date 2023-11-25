namespace NuiN.ScriptableVariables
{
    using UnityEngine;
    using NuiN.ScriptableVariables.Base;
    using System.Collections.Generic;
    
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<Color>", fileName = "New ColorList Variable")]
    internal class ColorListSO : VariableSO<List<Color>> { }
}