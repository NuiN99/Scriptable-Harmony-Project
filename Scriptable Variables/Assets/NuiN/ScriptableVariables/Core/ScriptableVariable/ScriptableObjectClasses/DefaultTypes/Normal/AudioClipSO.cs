using UnityEngine;
using NuiN.ScriptableVariables.Core.ScriptableVariable.ScriptableObjectClasses.Base;

namespace NuiN.ScriptableVariables.Core.ScriptableVariable.ScriptableObjectClasses
{   
    [CreateAssetMenu(menuName = "ScriptableVariables/Normal/AudioClip", fileName = "New AudioClip Variable")]
    internal class AudioClipSO : ScriptableVariableBaseSO<AudioClip> { }
}