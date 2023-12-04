using UnityEngine;
using NuiN.ScriptableVariables.Core.RuntimeSingle.Base;

namespace NuiN.ScriptableVariables.CustomTypes.RuntimeSingles
{   
    [CreateAssetMenu(
        menuName = "ScriptableVariables/Common/RuntimeSingles/Rigidbody2D", 
        fileName = "New Rigidbody2D RuntimeSingle")]

    internal class Rigidbody2DRuntimeSingleSO : RuntimeSingleBaseSO<Rigidbody2D> { }
}