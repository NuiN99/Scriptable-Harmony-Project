using NuiN.ScriptableVariables.Variable.Base;
using UnityEngine;

namespace NuiN.ScriptableVariables.Variable.Common
{   
    [CreateAssetMenu(
        menuName = "ScriptableVariables/Common/Variables/AudioClip", 
        fileName = "New AudioClip Variable")]
    internal class AudioClipSO : ScriptableVariableBaseSO<AudioClip> { }
}