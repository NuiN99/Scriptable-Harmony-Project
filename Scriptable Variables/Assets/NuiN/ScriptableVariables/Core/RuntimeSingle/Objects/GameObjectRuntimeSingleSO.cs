using UnityEngine;
using NuiN.ScriptableVariables.RuntimeSingle.Base;

namespace NuiN.ScriptableVariables.RuntimeSingle.Common
{
    [CreateAssetMenu(
        menuName = "ScriptableVariables/Common/RuntimeSingles/GameObject", 
        fileName = "New GameObject RuntimeSingle")]
    public class GameObjectRuntimeSingleSO : RuntimeSingleBaseSO<GameObject> { }
}

