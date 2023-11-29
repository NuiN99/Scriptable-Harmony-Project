using UnityEngine;
using NuiN.ScriptableVariables.Core.Base;
using System.Collections.Generic;

namespace NuiN.ScriptableVariables.Types
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<Sprite>", fileName = "New SpriteList Variable")]
    internal class SpriteListSO : ScriptableVariableBaseSO<List<Sprite>> { }
}