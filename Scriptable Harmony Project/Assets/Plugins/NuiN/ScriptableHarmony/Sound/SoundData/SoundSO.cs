using UnityEngine;

namespace NuiN.ScriptableHarmony.Sound
{
    [CreateAssetMenu(menuName = "ScriptableHarmony/Sound/Sound", fileName = "New Sound")]
    public class SoundSO : SoundBaseSO
    {
        [SerializeField] AudioClip audioClip;

        public AudioClip Clip => audioClip;
        
        protected override AudioClip GetClip() => audioClip;
    }
}