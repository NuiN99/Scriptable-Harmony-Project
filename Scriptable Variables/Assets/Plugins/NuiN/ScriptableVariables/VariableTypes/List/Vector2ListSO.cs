using NuiN.ScriptableVariables.Base;

namespace NuiN.ScriptableVariables
{
    using UnityEngine; 
    using System.Collections.Generic;
    
    [CreateAssetMenu(menuName = "ScriptableObjects/Variables/List<Vector2>", fileName = "New Vector2List Variable")]
    public class Vector2ListSO : VariableSO<List<Vector2>> { }
}