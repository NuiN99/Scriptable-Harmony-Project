namespace NuiN.ScriptableVariables
{
    using UnityEngine;
    using NuiN.ScriptableVariables.Base;
    using System.Collections.Generic;
    
    [CreateAssetMenu(menuName = "ScriptableObjects/Variables/List<Color>", fileName = "New ColorList Variable")]
    public class ColorListSO : VariableSO<List<Color>> { }
}