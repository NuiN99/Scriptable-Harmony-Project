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
        [SerializeField] float globalEmissionFactor = 1f;
        [SerializeField] float globalScaleFactor = 1f;
        [SerializeField] bool disableParticles;
        
        public void Spawn(ParticleSystem particleSystem, Vector3 position, Quaternion rotation = default, Transform parent = null, float emissionFactor = 1f, float scaleFactor = 1f)
        {
            if (disableParticles) return;
            ParticleSystem system = Instantiate(particleSystem, position, rotation, parent);
            var emission = system.emission;
            var curve = system.emission.rateOverTime;
            curve.curveMultiplier = emissionFactor * globalEmissionFactor;
            emission.rateOverTime = system.emission.rateOverTime;
            particleSystem.transform.localScale *= scaleFactor * globalScaleFactor;
        }
        public void SpawnRandom(List<ParticleSystem> particleSystems, Vector3 position, Quaternion rotation = default, Transform parent = null, float emissionFactor = 1f, float scaleFactor = 1f)
        {
            if (disableParticles) return;
            
            ParticleSystem randSystem = particleSystems[Random.Range(0, particleSystems.Count)];
            Spawn(randSystem, position, rotation, parent, emissionFactor, scaleFactor);
        }

        public void Spawn(ParticleSystem particleSystem, GetVariable<Vector3> position, Quaternion rotation = default, Transform parent = null, float emissionFactor = 1f, float scaleFactor = 1f)
            => Spawn(particleSystem, position.Val, rotation, parent, emissionFactor, globalEmissionFactor);
        public void Spawn(ParticleSystem particleSystem, SetVariable<Vector3> position, Quaternion rotation = default, Transform parent = null, float emissionFactor = 1f, float scaleFactor = 1f)
            => Spawn(particleSystem, position.Val, rotation, parent, emissionFactor, globalEmissionFactor);
        public void Spawn(ParticleSystem particleSystem, GetVariable<Vector2> position, Quaternion rotation = default, Transform parent = null, float emissionFactor = 1f, float scaleFactor = 1f)
            => Spawn(particleSystem, position.Val, rotation, parent, emissionFactor, globalEmissionFactor);
        public void Spawn(ParticleSystem particleSystem, SetVariable<Vector2> position, Quaternion rotation = default, Transform parent = null, float emissionFactor = 1f, float scaleFactor = 1f)
            => Spawn(particleSystem, position.Val, rotation, parent, emissionFactor, globalEmissionFactor);
        
        public void SpawnRandom(List<ParticleSystem> particleSystems, GetVariable<Vector3> position, Quaternion rotation = default, Transform parent = null, float emissionFactor = 1f, float scaleFactor = 1f)
            => Spawn(particleSystems[Random.Range(0, particleSystems.Count)], position.Val, rotation, parent, emissionFactor, globalEmissionFactor);
        public void SpawnRandom(List<ParticleSystem> particleSystems, SetVariable<Vector3> position, Quaternion rotation = default, Transform parent = null, float emissionFactor = 1f, float scaleFactor = 1f)
            => Spawn(particleSystems[Random.Range(0, particleSystems.Count)], position.Val, rotation, parent, emissionFactor, globalEmissionFactor);
        public void SpawnRandom(List<ParticleSystem> particleSystems, GetVariable<Vector2> position, Quaternion rotation = default, Transform parent = null, float emissionFactor = 1f, float scaleFactor = 1f)
            => Spawn(particleSystems[Random.Range(0, particleSystems.Count)], position.Val, rotation, parent, emissionFactor, globalEmissionFactor);
        public void SpawnRandom(List<ParticleSystem> particleSystems, SetVariable<Vector2> position, Quaternion rotation = default, Transform parent = null, float emissionFactor = 1f, float scaleFactor = 1f)
            => Spawn(particleSystems[Random.Range(0, particleSystems.Count)], position.Val, rotation, parent, emissionFactor, globalEmissionFactor);
    }
}
