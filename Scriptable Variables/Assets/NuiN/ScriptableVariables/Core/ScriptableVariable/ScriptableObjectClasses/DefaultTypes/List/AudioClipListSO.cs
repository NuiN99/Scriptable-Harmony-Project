using UnityEngine;
using NuiN.ScriptableVariables.Core.Base;
using System.Collections.Generic;

namespace NuiN.ScriptableVariables.Types
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/List/List<AudioClip>", fileName = "New AudioClipList Variable")]
    internal class AudioClipListSO : ScriptableVariableBaseSO<List<AudioClip>> { }
}