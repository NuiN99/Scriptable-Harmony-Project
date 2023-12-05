using NuiN.ScriptableVariables.References;
using NuiN.ScriptableVariables.RuntimeSet.References;
using NuiN.ScriptableVariables.RuntimeSingle.References;
using NuiN.ScriptableVariables.Variable.References;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header("Writers")]
    [SerializeField] SetVariable<float> maxHealth;
    [SerializeField] SetVariable<float> curHealth;

    GetRuntimeSingle<Enemy> test;

    public void TakeDamage(float amount)
    {
        test.Entity.name = null;
        curHealth.SubtractClamped(amount, min: 0, max: maxHealth.Val);
    }

    // temp for testing
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if(Input.GetMouseButtonDown(0)) TakeDamage(10);
    }
}
