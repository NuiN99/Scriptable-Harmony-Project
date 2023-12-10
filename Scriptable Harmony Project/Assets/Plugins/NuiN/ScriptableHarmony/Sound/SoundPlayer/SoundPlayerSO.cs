using System;
using System.Collections.Generic;
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
    
        public void Play(AudioClip clip, float volume = 1)
        {
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
            AudioClip randClip = clips[Random.Range(0, clips.Count)];
            Play(randClip, volume);
        }

        public AudioSource PlaySpatial(AudioClip clip, Vector3 position, float volume = 1, Transform parent = null)
        {
            AudioSource source = Instantiate(spatialSourcePrefab, position, Quaternion.identity, parent);
            source.outputAudioMixerGroup = mixerGroup;
            source.clip = clip;
            source.volume = volume * masterVolume;
            source.Play();
            Destroy(source.gameObject, clip.length / Mathf.Max(Math.Abs(source.pitch), Mathf.Epsilon));
            return source;
        }
        public AudioSource PlayRandomSpatial(List<AudioClip> clips, Vector3 position, float volume = 1, Transform parent = null)
        {
            AudioClip randClip = clips[Random.Range(0, clips.Count)];
            return PlaySpatial(randClip, position, volume, parent);
        }
    }
}
