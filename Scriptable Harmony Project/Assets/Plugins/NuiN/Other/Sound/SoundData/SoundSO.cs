using System.Diagnostics;
using UnityEditor;
using UnityEngine;

namespace NuiN.ScriptableHarmony.Sound
{
    [CreateAssetMenu(menuName = "ScriptableHarmony/Sound/SoundSO", fileName = "New Sound")]
    public class SoundSO : SoundBaseSO
    {
        [SerializeField] AudioClip audioClip;

        public AudioClip Clip => audioClip;
        
        protected override AudioClip GetClip() => audioClip;

        public static SoundSO CreateInstance(AudioClip clip)
        {
            var obj = CreateInstance<SoundSO>();
            obj.audioClip = clip;
            return obj;
        }
    }
}