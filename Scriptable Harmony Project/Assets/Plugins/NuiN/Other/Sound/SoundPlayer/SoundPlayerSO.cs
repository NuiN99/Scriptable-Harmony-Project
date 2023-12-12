using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NuiN.ScriptableHarmony.References;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace NuiN.ScriptableHarmony.Sound
{
    [CreateAssetMenu(menuName = "ScriptableHarmony/Sound/Player", fileName = "New Sound Player")]
    public class SoundPlayerSO : ScriptableObject
    {
        AudioSource _activeSource;
        bool _sceneDisabledAudio;
    
        [Range(0,1)] public float masterVolume = 1f;
        
        [SerializeField] [Tooltip("Sets the Source's mixer group")] AudioMixerGroup mixerGroup;
        
        [Header("Prefabs")]
        [SerializeField] AudioSource source;
        [SerializeField] AudioSource spatialSource;

        [Header("Options")]
        public bool disableAudio;
        [SerializeField] List<string> disableAudioOnScenes;
        
        void OnEnable() => SceneManager.activeSceneChanged += CheckDisabledScenes;
        void OnDisable() => SceneManager.activeSceneChanged -= CheckDisabledScenes;

        void CheckDisabledScenes(Scene from, Scene to)
        {
            if (disableAudioOnScenes.Any(sceneName => sceneName != null && sceneName == to.name))
            {
                _sceneDisabledAudio = true;
                return;
            }

            _sceneDisabledAudio = false;
        }

        public void Play(AudioClip clip, float volume = 1)
        {
            if (disableAudio || _sceneDisabledAudio) return;
            
            if (_activeSource == null)
            {
                _activeSource = Instantiate(source);
                _activeSource.name = "Scriptable Harmony AudioSource";
                _activeSource.outputAudioMixerGroup = mixerGroup;
            }
        
            _activeSource.PlayOneShot(clip, volume * masterVolume);
        }
        public void PlayRandom(List<AudioClip> clips, float volume = 1)
        {
            if (disableAudio || _sceneDisabledAudio) return;
            
            AudioClip randClip = clips[Random.Range(0, clips.Count)];
            Play(randClip, volume);
        }
        
        void PlaySoundSpatial(AudioClip clip, Vector3 position, float volume = 1, Transform parent = null)
        {
            if (disableAudio || _sceneDisabledAudio) return;
            
            AudioSource audioSource = Instantiate(spatialSource, position, Quaternion.identity, parent);
            audioSource.outputAudioMixerGroup = mixerGroup;
            audioSource.clip = clip;
            audioSource.volume = volume * masterVolume;
            audioSource.Play();
            Destroy(audioSource.gameObject, clip.length / Mathf.Max(Math.Abs(audioSource.pitch), Mathf.Epsilon));
        }

        public void PlaySpatial(AudioClip clip, Vector3 position, float volume = 1, Transform parent = null)
            => PlaySoundSpatial(clip, position, volume, parent);
        
        public void PlayRandomSpatial(List<AudioClip> clips, Vector3 position, float volume = 1, Transform parent = null)
            => PlaySpatial(clips[Random.Range(0, clips.Count)], position, volume, parent);
    }
}
