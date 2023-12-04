using UnityEngine;
using NuiN.ScriptableVariables.RuntimeSet.Base;

namespace NuiN.ScriptableVariables.CustomTypes.RuntimeSets
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/Custom/RuntimeSets/Enemy", fileName = "New Enemy RuntimeSet")]
    internal class EnemyRuntimeSetSO : RuntimeSetBaseSO<Enemy> { }
}