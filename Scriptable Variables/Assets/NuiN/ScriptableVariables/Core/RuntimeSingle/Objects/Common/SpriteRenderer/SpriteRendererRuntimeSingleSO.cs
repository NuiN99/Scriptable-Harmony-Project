using UnityEngine;
using NuiN.ScriptableVariables.RuntimeSingle.Base;

namespace NuiN.ScriptableVariables.RuntimeSingle.Common
{   
    [CreateAssetMenu(
        menuName = "ScriptableVariables/Custom/RuntimeSingles/SpriteRenderer", 
        fileName = "New SpriteRenderer RuntimeSingle")]
    internal class SpriteRendererRuntimeSingleSO : RuntimeSingleBaseSO<SpriteRenderer> { }
}