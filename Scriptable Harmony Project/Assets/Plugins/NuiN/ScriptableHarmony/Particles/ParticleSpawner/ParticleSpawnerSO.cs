using System;
using System.Collections.Generic;
using System.Linq;
using NuiN.ScriptableHarmony.References;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace NuiN.ScriptableHarmony.Particles
{
    [CreateAssetMenu(menuName = "ScriptableHarmony/Particles/Spawner", fileName = "New Particle Spawner")]
    public class ParticleSpawnerSO : ScriptableObject
    {
        [Header("Options")]
        [SerializeField] float globalEmissionMultiplier = 1f;
        [SerializeField] float globalScaleMultiplier = 1f;
        [SerializeField] bool disableParticles;
        
        public void Spawn(ParticleSystem particleSystem, Vector3 position, Quaternion rotation = default, Transform parent = null, float emissionMultiplier = 1f, float scaleMultiplier = 1f)
        {
            if (disableParticles) return;
            ParticleSystem newSystem = Instantiate(particleSystem, position, rotation, parent);
            var emission = newSystem.emission;
            
            newSystem.transform.localScale *= scaleMultiplier * globalScaleMultiplier;
            emission.rateOverTimeMultiplier *= emissionMultiplier * globalEmissionMultiplier;
        }
        
        public void SpawnRandom(List<ParticleSystem> particleSystems, Vector3 position, Quaternion rotation = default, Transform parent = null, float emissionMultiplier = 1f, float scaleMultiplier = 1f)
        {
            if (disableParticles) return;
            
            ParticleSystem randSystem = particleSystems[Random.Range(0, particleSystems.Count)];
            Spawn(randSystem, position, rotation, parent, emissionMultiplier, scaleMultiplier);
        }

        public void Spawn(ParticleSystem particleSystem, GetVariable<Vector3> position, Quaternion rotation = default, Transform parent = null, float emissionMultiplier = 1f, float scaleMultiplier = 1f)
            => Spawn(particleSystem, position.Val, rotation, parent, emissionMultiplier, scaleMultiplier);
        public void Spawn(ParticleSystem particleSystem, SetVariable<Vector3> position, Quaternion rotation = default, Transform parent = null, float emissionMultiplier = 1f, float scaleMultiplier = 1f)
            => Spawn(particleSystem, position.Val, rotation, parent, emissionMultiplier, scaleMultiplier);
        public void Spawn(ParticleSystem particleSystem, GetVariable<Vector2> position, Quaternion rotation = default, Transform parent = null, float emissionMultiplier = 1f, float scaleMultiplier = 1f)
            => Spawn(particleSystem, position.Val, rotation, parent, emissionMultiplier, scaleMultiplier);
        public void Spawn(ParticleSystem particleSystem, SetVariable<Vector2> position, Quaternion rotation = default, Transform parent = null, float emissionMultiplier = 1f, float scaleMultiplier = 1f)
            => Spawn(particleSystem, position.Val, rotation, parent, emissionMultiplier, scaleMultiplier);
        
        public void SpawnRandom(List<ParticleSystem> particleSystems, GetVariable<Vector3> position, Quaternion rotation = default, Transform parent = null, float emissionMultiplier = 1f, float scaleMultiplier = 1f)
            => Spawn(particleSystems[Random.Range(0, particleSystems.Count)], position.Val, rotation, parent, emissionMultiplier, scaleMultiplier);
        public void SpawnRandom(List<ParticleSystem> particleSystems, SetVariable<Vector3> position, Quaternion rotation = default, Transform parent = null, float emissionMultiplier = 1f, float scaleMultiplier = 1f)
            => Spawn(particleSystems[Random.Range(0, particleSystems.Count)], position.Val, rotation, parent, emissionMultiplier, scaleMultiplier);
        public void SpawnRandom(List<ParticleSystem> particleSystems, GetVariable<Vector2> position, Quaternion rotation = default, Transform parent = null, float emissionMultiplier = 1f, float scaleMultiplier = 1f)
            => Spawn(particleSystems[Random.Range(0, particleSystems.Count)], position.Val, rotation, parent, emissionMultiplier, scaleMultiplier);
        public void SpawnRandom(List<ParticleSystem> particleSystems, SetVariable<Vector2> position, Quaternion rotation = default, Transform parent = null, float emissionMultiplier = 1f, float scaleMultiplier = 1f)
            => Spawn(particleSystems[Random.Range(0, particleSystems.Count)], position.Val, rotation, parent, emissionMultiplier, scaleMultiplier);
    }
}
