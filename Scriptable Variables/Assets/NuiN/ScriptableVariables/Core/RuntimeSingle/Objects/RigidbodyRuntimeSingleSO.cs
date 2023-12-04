using UnityEngine;
using NuiN.ScriptableVariables.RuntimeSingle.Base;

namespace NuiN.ScriptableVariables.RuntimeSingle.Common
{   
    [CreateAssetMenu(
        menuName = "ScriptableVariables/Common/RuntimeSingles/Rigidbody", 
        fileName = "New Rigidbody RuntimeSingle")]

    internal class RigidbodyRuntimeSingleSO : RuntimeSingleBaseSO<Rigidbody> { }
}