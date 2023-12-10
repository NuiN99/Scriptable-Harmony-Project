using System;
using System.Collections.Generic;
using NuiN.ScriptableHarmony.References;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

namespace NuiN.ScriptableHarmony.Sound
{
    [CreateAssetMenu(menuName = "ScriptableHarmony/Sound/Player", fileName = "New Sound Player")]
    public class SoundPlayerSO : ScriptableObject
    {
        AudioSource _activeSource;
    
        [SerializeField] [Range(0,1)] float masterVolume = 1f;
        [SerializeField] [Tooltip("Sets the Source's mixer group")] AudioMixerGroup mixerGroup;
        [SerializeField] AudioSource sourcePrefab;
        [SerializeField] AudioSource spatialSourcePrefab;
        [SerializeField] bool disableAudio;
    
        public void Play(AudioClip clip, float volume = 1)
        {
            if (disableAudio) return;
            
            if (_activeSource == null)
            {
                _activeSource = Instantiate(sourcePrefab);
                _activeSource.name = "Scriptable Harmony AudioSource";
                _activeSource.outputAudioMixerGroup = mixerGroup;
            }
        
            _activeSource.PlayOneShot(clip, volume * masterVolume);
        }
        public void PlayRandom(List<AudioClip> clips, float volume = 1)
        {
            if (disableAudio) return;
            
            AudioClip randClip = clips[Random.Range(0, clips.Count)];
            Play(randClip, volume);
        }
        
        void PlaySoundSpatial(AudioClip clip, Vector3 position, float volume = 1, Transform parent = null)
        {
            if (disableAudio) return;
            
            AudioSource source = Instantiate(spatialSourcePrefab, position, Quaternion.identity, parent);
            source.outputAudioMixerGroup = mixerGroup;
            source.clip = clip;
            source.volume = volume * masterVolume;
            source.Play();
            Destroy(source.gameObject, clip.length / Mathf.Max(Math.Abs(source.pitch), Mathf.Epsilon));
        }

        public void PlaySpatial(AudioClip clip, Vector3 position, float volume = 1, Transform parent = null)
            => PlaySoundSpatial(clip, position, volume, parent);
        public void PlaySpatial(AudioClip clip, GetVariable<Vector3> position, float volume = 1, Transform parent = null)
            => PlaySoundSpatial(clip, position.Val, volume, parent);
        public void PlaySpatial(AudioClip clip, SetVariable<Vector3> position, float volume = 1, Transform parent = null)
            => PlaySoundSpatial(clip, position.Val, volume, parent);
        public void PlaySpatial(AudioClip clip, GetVariable<Vector2> position, float volume = 1, Transform parent = null)
            => PlaySoundSpatial(clip, position.Val, volume, parent);
        public void PlaySpatial(AudioClip clip, SetVariable<Vector2> position, float volume = 1, Transform parent = null)
            => PlaySoundSpatial(clip, position.Val, volume, parent);
        
        public void PlayRandomSpatial(List<AudioClip> clips, Vector3 position, float volume = 1, Transform parent = null)
            => PlaySpatial(clips[Random.Range(0, clips.Count)], position, volume, parent);
        public void PlayRandomSpatial(List<AudioClip> clips, GetVariable<Vector3> position, float volume = 1, Transform parent = null)
            => PlaySpatial(clips[Random.Range(0, clips.Count)], position, volume, parent);
        public void PlayRandomSpatial(List<AudioClip> clips, SetVariable<Vector3> position, float volume = 1, Transform parent = null)
            => PlaySpatial(clips[Random.Range(0, clips.Count)], position, volume, parent);
        public void PlayRandomSpatial(List<AudioClip> clips, GetVariable<Vector2> position, float volume = 1, Transform parent = null)
            => PlaySpatial(clips[Random.Range(0, clips.Count)], position, volume, parent);
        public void PlayRandomSpatial(List<AudioClip> clips, SetVariable<Vector2> position, float volume = 1, Transform parent = null)
            => PlaySpatial(clips[Random.Range(0, clips.Count)], position, volume, parent);
    }
}
