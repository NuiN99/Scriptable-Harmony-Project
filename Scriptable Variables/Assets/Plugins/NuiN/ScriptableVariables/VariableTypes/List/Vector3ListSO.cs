using NuiN.ScriptableVariables.Base;

namespace NuiN.ScriptableVariables
{
    using UnityEngine; 
    using System.Collections.Generic;
    
    [CreateAssetMenu(menuName = "ScriptableObjects/Variables/List<Vector3>", fileName = "New Vector3List Variable")]
    public class Vector3ListSO : VariableSO<List<Vector3>> { }
}