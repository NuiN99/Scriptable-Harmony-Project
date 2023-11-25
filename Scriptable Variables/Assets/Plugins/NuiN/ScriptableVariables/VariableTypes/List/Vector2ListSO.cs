using NuiN.ScriptableVariables.Base;

namespace NuiN.ScriptableVariables
{
    using UnityEngine; 
    using System.Collections.Generic;
    
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<Vector2>", fileName = "New Vector2List Variable")]
    internal class Vector2ListSO : VariableSO<List<Vector2>> { }
}