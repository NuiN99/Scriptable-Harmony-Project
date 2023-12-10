using System;
using UnityEditor;
using UnityEngine;

namespace NuiN.ScriptableHarmony.Sound
{
    public abstract class SoundBaseSO : ScriptableObject
    {
        [SerializeField] protected SoundPlayerSO player;
        [SerializeField] [Range(0, 1)] protected float volume = 1f;
        protected abstract AudioClip GetClip();

        public void Play(float volumeFactor = 1)
            => player.Play(GetClip(), volume * volumeFactor);

        public void PlaySpatial(Vector3 position, float volumeFactor = 1, Transform parent = null)
            => player.PlaySpatial(GetClip(), position, volume * volumeFactor, parent);
    }
}