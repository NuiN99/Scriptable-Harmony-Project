using UnityEngine;

namespace NuiN.ScriptableHarmony.Sound
{
    [CreateAssetMenu(menuName = "ScriptableHarmony/Sound/Sound Array", fileName = "New Sound Array")]
    public class SoundArraySO : SoundBaseSO
    {
        [SerializeField] AudioClip[] audioClips;
        protected override AudioClip GetClip()
            => audioClips[Random.Range(0, audioClips.Length)];

        public void PlayIndex(int index, float volumeFactor = 1)
            => player.Play(audioClips[index], volume * volumeFactor);

        public void PlayIndexSpatial(int index, Vector3 position, float volumeFactor = 1, Transform parent = null)
            => player.PlaySpatial(audioClips[index], position, volume * volumeFactor, parent);
    }
}