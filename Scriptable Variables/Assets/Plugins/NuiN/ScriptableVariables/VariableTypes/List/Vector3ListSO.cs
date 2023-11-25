using NuiN.ScriptableVariables.Base;

namespace NuiN.ScriptableVariables
{
    using UnityEngine; 
    using System.Collections.Generic;
    
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<Vector3>", fileName = "New Vector3List Variable")]
    internal class Vector3ListSO : VariableSO<List<Vector3>> { }
}