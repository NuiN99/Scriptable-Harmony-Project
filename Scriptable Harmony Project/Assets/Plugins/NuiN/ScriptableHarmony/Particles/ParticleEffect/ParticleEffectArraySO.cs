using NuiN.ScriptableHarmony.Particles;
using NuiN.ScriptableHarmony.References;
using UnityEngine;

namespace NuiN.ScriptableHarmony.Particles
{
    [CreateAssetMenu(menuName = "ScriptableHarmony/Particles/Particle Effect Array", fileName = "New Particle Effect Array")]
    public class ParticleEffectArraySO : ParticleEffectBaseSO
    {
        [SerializeField] ParticleSystem[] particleSystems;
        public ParticleSystem[] ParticleSystems => particleSystems;
        
        protected override ParticleSystem GetParticleSystem()
            => particleSystems[Random.Range(0, particleSystems.Length)];

        public void SpawnIndex(int index, Vector3 position, Quaternion rotation = default, Transform parent = null, float emissionMult = 1f, float scaleMult = 1f)
            => spawner.Spawn(particleSystems[index], position, rotation, parent, emissionMult, scaleMult);
        public void SpawnIndex(int index, GetVariable<Vector3> position, Quaternion rotation = default, Transform parent = null, float emissionMult = 1f, float scaleMult = 1f)
            => spawner.Spawn(particleSystems[index], position, rotation, parent, emissionMult, scaleMult);
        public void SpawnIndex(int index, SetVariable<Vector3> position, Quaternion rotation = default, Transform parent = null, float emissionMult = 1f, float scaleMult = 1f)
            => spawner.Spawn(particleSystems[index], position, rotation, parent, emissionMult, scaleMult);
        public void SpawnIndex(int index, GetVariable<Vector2> position, Quaternion rotation = default, Transform parent = null, float emissionMult = 1f, float scaleMult = 1f)
            => spawner.Spawn(particleSystems[index], position, rotation, parent, emissionMult, scaleMult);
        public void SpawnIndex(int index, SetVariable<Vector2> position, Quaternion rotation = default, Transform parent = null, float emissionMult = 1f, float scaleMult = 1f)
            => spawner.Spawn(particleSystems[index], position, rotation, parent, emissionMult, scaleMult);
    }
}