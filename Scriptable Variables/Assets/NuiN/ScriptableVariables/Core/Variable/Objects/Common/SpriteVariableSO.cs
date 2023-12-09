using NuiN.ScriptableVariables.Variable.Base;
using UnityEngine;

namespace NuiN.ScriptableVariables.Variable.Common
{   
    [CreateAssetMenu(
        menuName = "ScriptableVariables/Common/Variables/Sprite", 
        fileName = "New Sprite Variable")]
    internal class SpriteVariableSO : ScriptableVariableBaseSO<Sprite> { }
}