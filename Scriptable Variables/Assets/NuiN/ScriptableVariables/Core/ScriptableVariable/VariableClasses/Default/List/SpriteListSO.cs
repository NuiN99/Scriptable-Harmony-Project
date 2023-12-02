using UnityEngine;
using System.Collections.Generic;
using NuiN.ScriptableVariables.Core.Variable.SOClasses.Base;

namespace NuiN.ScriptableVariables.Core.Variable.SOClasses
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<Sprite>", fileName = "New SpriteList Variable")]
    internal class SpriteListSO : ScriptableVariableBaseSO<List<Sprite>> { }
}