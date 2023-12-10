using NuiN.ScriptableHarmony.Particles;
using NuiN.ScriptableHarmony.References;
using NuiN.ScriptableHarmony.Sound;
using NuiN.ScriptableHarmony.Variable.References;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header("Writers")]
    [SerializeField] SetVariable<float> maxHealth;
    [SerializeField] SetVariable<float> curHealth;
    [SerializeField] GetVariable<Vector2> mousePosition;

    [SerializeField] SoundSO clickSound;
    [SerializeField] ParticleEffectArraySO clickParticles;

    public void TakeDamage(float amount)
    {
        curHealth.SubtractClamped(amount, min: 0, max: maxHealth.Val);
    }

    // temp for testing
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (Input.GetMouseButtonDown(0))
        {
            TakeDamage(10);
            clickSound.PlaySpatial(mousePosition);
            clickParticles.SpawnAll(mousePosition);
        }
    }
}
