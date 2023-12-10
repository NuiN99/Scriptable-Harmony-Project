using System;
using NuiN.ScriptableHarmony.References;
using UnityEditor;
using UnityEngine;

namespace NuiN.ScriptableHarmony.Sound
{
    public abstract class SoundBaseSO : ScriptableObject
    {
        [SerializeField] protected SoundPlayerSO player;
        [SerializeField] [Range(0, 1)] protected float volume = 1f;

        public SoundPlayerSO SoundPlayer => player;
        public float Volume => volume;
        
        protected abstract AudioClip GetClip();

        public void Play(float volumeFactor = 1)
            => player.Play(GetClip(), volume * volumeFactor);

        public AudioSource PlaySpatial(Vector3 position, Transform parent = null, float volumeFactor = 1)
            => player.PlaySpatial(GetClip(), position, volume * volumeFactor, parent);
        public AudioSource PlaySpatial(GetVariable<Vector3> position, Transform parent = null, float volumeFactor = 1)
            => player.PlaySpatial(GetClip(), position, volume * volumeFactor, parent);
        public AudioSource PlaySpatial(SetVariable<Vector3> position, Transform parent = null, float volumeFactor = 1)
            => player.PlaySpatial(GetClip(), position, volume * volumeFactor, parent);
        public AudioSource PlaySpatial(GetVariable<Vector2> position, Transform parent = null, float volumeFactor = 1)
            => player.PlaySpatial(GetClip(), position, volume * volumeFactor, parent);
        public AudioSource PlaySpatial(SetVariable<Vector2> position, Transform parent = null, float volumeFactor = 1)
            => player.PlaySpatial(GetClip(), position, volume * volumeFactor, parent);
    }
}