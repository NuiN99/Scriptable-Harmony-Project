using NuiN.ScriptableVariables.Core.Variable.Base;
using UnityEngine;

namespace NuiN.ScriptableVariables.Core.Variable.SOClasses
{   
    [CreateAssetMenu(
        menuName = "ScriptableVariables/Common/Variables/AudioClip", 
        fileName = "New AudioClip Variable")]
    internal class AudioClipSO : ScriptableVariableBaseSO<AudioClip> { }
}