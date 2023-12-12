using NuiN.ScriptableHarmony.References;
using UnityEngine;

namespace NuiN.ScriptableHarmony.Sound
{
    [CreateAssetMenu(menuName = "ScriptableHarmony/Sound/Sound Array", fileName = "New Sound Array")]
    public class SoundArraySO : SoundBaseSO
    {
        [SerializeField] AudioClip[] audioClips;

        public AudioClip[] AudioClips => audioClips;
        
        protected override AudioClip GetClip()
            => audioClips[Random.Range(0, audioClips.Length)];

        public void PlayIndex(int index, float volumeFactor = 1)
            => player.Play(audioClips[index], volume * volumeFactor);

        public void PlayAll(float volumeFactor = 1)
        {
            foreach(var clip in audioClips) player.Play(clip, volume * volumeFactor);
        }

        public void PlayIndexSpatial(int index, Vector3 position, Transform parent = null, float volumeFactor = 1)
            => player.PlaySpatial(audioClips[index], position, volume * volumeFactor, parent);
        public void PlayIndexSpatial(int index, GetVariable<Vector3> position, Transform parent = null, float volumeFactor = 1)
            => player.PlaySpatial(audioClips[index], position, volume * volumeFactor, parent);
        public void PlayIndexSpatial(int index, SetVariable<Vector3> position, Transform parent = null, float volumeFactor = 1)
            => player.PlaySpatial(audioClips[index], position, volume * volumeFactor, parent);
        public void PlayIndexSpatial(int index, GetVariable<Vector2> position, Transform parent = null, float volumeFactor = 1)
            => player.PlaySpatial(audioClips[index], position, volume * volumeFactor, parent);
        public void PlayIndexSpatial(int index, SetVariable<Vector2> position, Transform parent = null, float volumeFactor = 1)
            => player.PlaySpatial(audioClips[index], position, volume * volumeFactor, parent);
        
        public void PlayAllSpatial(Vector3 position, Transform parent = null, float volumeFactor = 1)
        {
            foreach(var clip in audioClips) player.PlaySpatial(clip, position, volume * volumeFactor, parent);
        }
        public void PlayAllSpatial(GetVariable<Vector3> position, Transform parent = null, float volumeFactor = 1)
        {
            foreach(var clip in audioClips) player.PlaySpatial(clip, position, volume * volumeFactor, parent);
        }
        public void PlayAllSpatial(SetVariable<Vector3> position, Transform parent = null, float volumeFactor = 1)
        {
            foreach(var clip in audioClips) player.PlaySpatial(clip, position, volume * volumeFactor, parent);
        }
        public void PlayAllSpatial(GetVariable<Vector2> position, Transform parent = null, float volumeFactor = 1)
        {
            foreach(var clip in audioClips) player.PlaySpatial(clip, position, volume * volumeFactor, parent);
        }
        public void PlayAllSpatial(SetVariable<Vector2> position, Transform parent = null, float volumeFactor = 1)
        {
            foreach(var clip in audioClips) player.PlaySpatial(clip, position, volume * volumeFactor, parent);
        }
    }
}