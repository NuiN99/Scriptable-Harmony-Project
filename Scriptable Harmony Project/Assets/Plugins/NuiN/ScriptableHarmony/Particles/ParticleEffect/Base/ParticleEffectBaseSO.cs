using System;
using NuiN.ScriptableHarmony.References;
using UnityEditor;
using UnityEngine;

namespace NuiN.ScriptableHarmony.Particles
{
    public abstract class ParticleEffectBaseSO : ScriptableObject
    {
        [SerializeField] protected ParticleSpawnerSO spawner;
        [SerializeField] protected float emissionMultiplier = 1f;
        [SerializeField] protected float scaleMultiplier = 1f;
        
        public ParticleSpawnerSO ParticleSpawner => spawner;
        public float EmissionMultiplier => emissionMultiplier;
        public float ScaleMultiplier => scaleMultiplier;
        
        protected abstract ParticleSystem GetParticleSystem();

        public void Spawn(Vector3 position, Quaternion rotation = default, Transform parent = null)
            => spawner.Spawn(GetParticleSystem(), position, rotation, parent, emissionMultiplier, scaleMultiplier);
        public void Spawn(GetVariable<Vector3> position, Quaternion rotation = default, Transform parent = null)
            => spawner.Spawn(GetParticleSystem(), position, rotation, parent, emissionMultiplier, scaleMultiplier);
        public void Spawn(SetVariable<Vector3> position, Quaternion rotation = default, Transform parent = null)
            => spawner.Spawn(GetParticleSystem(), position, rotation, parent, emissionMultiplier, scaleMultiplier);
        public void Spawn(GetVariable<Vector2> position, Quaternion rotation = default, Transform parent = null)
            => spawner.Spawn(GetParticleSystem(), position, rotation, parent, emissionMultiplier, scaleMultiplier);
        public void Spawn(SetVariable<Vector2> position, Quaternion rotation = default, Transform parent = null)
            => spawner.Spawn(GetParticleSystem(), position, rotation, parent, emissionMultiplier, scaleMultiplier);
    }
}