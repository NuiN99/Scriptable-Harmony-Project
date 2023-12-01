using UnityEngine;
using NuiN.ScriptableVariables.Core.Base;

namespace NuiN.ScriptableVariables.Types
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/Normal/AudioClip", fileName = "New AudioClip Variable")]
    internal class AudioClipSO : ScriptableVariableBaseSO<AudioClip> { }
}