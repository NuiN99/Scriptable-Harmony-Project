using UnityEngine;
using NuiN.ScriptableVariables.RuntimeSingle.Base;

namespace NuiN.ScriptableVariables.RuntimeSingle.Common
{   
    [CreateAssetMenu(
        menuName = "ScriptableVariables/Common/RuntimeSingles/Transform", 
        fileName = "New Transform RuntimeSingle")]
    internal class TransformRuntimeSingleSO : RuntimeSingleBaseSO<Transform> { }
}