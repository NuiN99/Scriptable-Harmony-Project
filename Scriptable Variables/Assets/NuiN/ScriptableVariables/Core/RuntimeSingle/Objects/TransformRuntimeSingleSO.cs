using UnityEngine;
using NuiN.ScriptableVariables.Core.RuntimeSingle.Base;

namespace NuiN.ScriptableVariables.CustomTypes.RuntimeSingles
{   
    [CreateAssetMenu(
        menuName = "ScriptableVariables/Common/RuntimeSingles/Transform", 
        fileName = "New Transform RuntimeSingle")]
    internal class TransformRuntimeSingleSO : RuntimeSingleBaseSO<Transform> { }
}