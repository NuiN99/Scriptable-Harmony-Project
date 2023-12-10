using UnityEngine;

namespace NuiN.ScriptableHarmony.Sound
{
    [CreateAssetMenu(menuName = "ScriptableHarmony/Sound/Sound", fileName = "New Sound")]
    public class SoundSO : SoundBaseSO
    {
        [SerializeField] AudioClip audioClip;
        protected override AudioClip GetClip() => audioClip;
    }
}