using UnityEngine;
using NuiN.ScriptableVariables.Core.RuntimeSingle.Base;

namespace NuiN.ScriptableVariables.CustomTypes.RuntimeSingles
{   
    [CreateAssetMenu(
        menuName = "ScriptableVariables/Common/RuntimeSingles/Rigidbody", 
        fileName = "New Rigidbody RuntimeSingle")]

    internal class RigidbodyRuntimeSingleSO : RuntimeSingleBaseSO<Rigidbody> { }
}