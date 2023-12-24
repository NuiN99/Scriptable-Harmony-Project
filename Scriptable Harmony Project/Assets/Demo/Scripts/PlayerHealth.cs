using NuiN.ScriptableHarmony.Particles;
using NuiN.ScriptableHarmony.References;
using NuiN.ScriptableHarmony.Sound;
using NuiN.ScriptableHarmony.Variable.References;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Writers")]
    [SerializeField] SetVariable<float> maxHealth;
    [SerializeField] SetVariable<float> curHealth;
    [SerializeField] GetVariable<Vector2> mousePosition;

    [SerializeField] ParticleEffectArraySO clickParticles;
    [SerializeField] ParticleEffectSO clickParticle;

    [SerializeField] SoundSO clickSound;

    [SerializeField] SetDictionaryVariable<int, bool> dictionary;

    public void TakeDamage(float amount)
    {
        curHealth.SubtractClamped(amount, min: 0, max: maxHealth.Val);
    }

    int curValue = 5;
    // temp for testing
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetMouseButtonDown(0))
        {
            TakeDamage(10);
            clickParticles.SpawnAll(mousePosition);
            
            clickParticle.Spawn(
                position: mousePosition, 
                rotation: Random.rotation, 
                parent: transform, 
                emissionFactor: 2f, 
                scaleFactor: 2f, 
                lifetime: 2f);
            
            clickSound.PlaySpatial(mousePosition.Val);

            dictionary.TryAdd(curValue, true);
            curValue++;
        }
    }
}
