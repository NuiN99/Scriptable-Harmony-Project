using System;
using NuiN.ScriptableHarmony.References;
using UnityEditor;
using UnityEngine;

namespace NuiN.ScriptableHarmony.Particles
{
    public abstract class ParticleEffectBaseSO : ScriptableObject
    {
        [SerializeField] protected ParticleSpawnerSO spawner;
        [SerializeField] float emissionMultiplier = 1f;
        [SerializeField] float scaleMultiplier = 1f;
        
        public ParticleSpawnerSO ParticleSpawner => spawner;
        public float EmissionMultiplier => emissionMultiplier;
        public float ScaleMultiplier => scaleMultiplier;
        
        protected abstract ParticleSystem GetParticleSystem();

        public void Spawn(Vector3 position, Quaternion rotation = default, Transform parent = null, float emissionMult = 1f, float scaleMult = 1f)
            => spawner.Spawn(GetParticleSystem(), position, rotation, parent, emissionMult, scaleMult);
        public void Spawn(GetVariable<Vector3> position, Quaternion rotation = default, Transform parent = null, float emissionMult = 1f, float scaleMult = 1f)
            => spawner.Spawn(GetParticleSystem(), position, rotation, parent, emissionMult, scaleMult);
        public void Spawn(SetVariable<Vector3> position, Quaternion rotation = default, Transform parent = null, float emissionMult = 1f, float scaleMult = 1f)
            => spawner.Spawn(GetParticleSystem(), position, rotation, parent, emissionMult, scaleMult);
        public void Spawn(GetVariable<Vector2> position, Quaternion rotation = default, Transform parent = null, float emissionMult = 1f, float scaleMult = 1f)
            => spawner.Spawn(GetParticleSystem(), position, rotation, parent, emissionMult, scaleMult);
        public void Spawn(SetVariable<Vector2> position, Quaternion rotation = default, Transform parent = null, float emissionMult = 1f, float scaleMult = 1f)
            => spawner.Spawn(GetParticleSystem(), position, rotation, parent, emissionMult, scaleMult);
    }
}