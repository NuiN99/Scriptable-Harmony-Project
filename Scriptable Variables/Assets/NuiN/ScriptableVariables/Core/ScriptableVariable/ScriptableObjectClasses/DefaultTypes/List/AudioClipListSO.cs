using UnityEngine;
using System.Collections.Generic;
using NuiN.ScriptableVariables.Core.ScriptableVariable.ScriptableObjectClasses.Base;

namespace NuiN.ScriptableVariables.Core.ScriptableVariable.ScriptableObjectClasses
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<AudioClip>", fileName = "New AudioClipList Variable")]
    internal class AudioClipListSO : ScriptableVariableBaseSO<List<AudioClip>> { }
}