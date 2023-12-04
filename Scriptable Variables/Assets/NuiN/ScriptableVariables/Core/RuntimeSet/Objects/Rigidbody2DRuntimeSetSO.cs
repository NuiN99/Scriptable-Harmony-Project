using UnityEngine;
using NuiN.ScriptableVariables.Core.RuntimeSet.Base;

namespace NuiN.ScriptableVariables.CustomTypes.RuntimeSets
{   
    [CreateAssetMenu(
        menuName = "ScriptableVariables/Common/RuntimeSets/Rigidbody2D", 
        fileName = "New Rigidbody2D RuntimeSet")]

    internal class Rigidbody2DRuntimeSetSO : RuntimeSetBaseSO<Rigidbody2D> { }
}