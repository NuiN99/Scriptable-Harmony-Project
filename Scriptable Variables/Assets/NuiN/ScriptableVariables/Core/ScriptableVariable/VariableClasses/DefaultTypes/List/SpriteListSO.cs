using UnityEngine;
using System.Collections.Generic;
using NuiN.ScriptableVariables.Core.ScriptableVariable.ScriptableObjectClasses.Base;

namespace NuiN.ScriptableVariables.Core.ScriptableVariable.ScriptableObjectClasses
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<Sprite>", fileName = "New SpriteList Variable")]
    internal class SpriteListSO : ScriptableVariableBaseSO<List<Sprite>> { }
}