using UnityEngine;
using System.Collections.Generic;
using NuiN.ScriptableVariables.Core.Variable.SOClasses.Base;

namespace NuiN.ScriptableVariables.Core.Variable.SOClasses
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<AudioClip>", fileName = "New AudioClipList Variable")]
    internal class AudioClipListSO : ScriptableVariableBaseSO<List<AudioClip>> { }
}