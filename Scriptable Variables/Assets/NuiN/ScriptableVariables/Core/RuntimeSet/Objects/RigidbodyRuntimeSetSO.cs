using NuiN.ScriptableVariables.RuntimeSet.Base;
using UnityEngine;

namespace NuiN.ScriptableVariables.RuntimeSet.Common
{   
    [CreateAssetMenu(
        menuName = "ScriptableVariables/Custom/RuntimeSets/Rigidbody", 
        fileName = "New Rigidbody RuntimeSet")]

    internal class RigidbodyRuntimeSetSO : RuntimeSetBaseSO<Rigidbody> { }
}