using UnityEngine;
using NuiN.ScriptableVariables.Core.RuntimeSet.Base;

namespace NuiN.ScriptableVariables.CustomTypes.RuntimeSets
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/Common/RuntimeSets/Transform", fileName = "New Transform RuntimeSet")]
    internal class TransformRuntimeSetSO : RuntimeSetBaseSO<Transform> { }
}