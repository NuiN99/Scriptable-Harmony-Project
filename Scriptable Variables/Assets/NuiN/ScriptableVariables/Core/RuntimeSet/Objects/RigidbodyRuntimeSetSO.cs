using UnityEngine;
using NuiN.ScriptableVariables.Core.RuntimeSet.Base;

namespace NuiN.ScriptableVariables.CustomTypes.RuntimeSets
{   
    [CreateAssetMenu(
        menuName = "ScriptableVariables/Custom/RuntimeSets/Rigidbody", 
        fileName = "New Rigidbody RuntimeSet")]

    internal class RigidbodyRuntimeSetSO : RuntimeSetBaseSO<Rigidbody> { }
}