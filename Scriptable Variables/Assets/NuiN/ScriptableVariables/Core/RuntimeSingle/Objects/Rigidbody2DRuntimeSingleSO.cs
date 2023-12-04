using UnityEngine;
using NuiN.ScriptableVariables.RuntimeSingle.Base;

namespace NuiN.ScriptableVariables.RuntimeSingle.Common
{   
    [CreateAssetMenu(
        menuName = "ScriptableVariables/Common/RuntimeSingles/Rigidbody2D", 
        fileName = "New Rigidbody2D RuntimeSingle")]
    internal class Rigidbody2DRuntimeSingleSO : RuntimeSingleBaseSO<Rigidbody2D> { }
}