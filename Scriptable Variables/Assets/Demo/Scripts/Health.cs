using NuiN.ScriptableVariables.Variable.References;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Writers")]
    [SerializeField] SetVariable<float> maxHealth;
    [SerializeField] SetVariable<float> curHealth;

    void Start()
    {
        curHealth.Set(maxHealth.Val);
    }

    public void TakeDamage(float amount)
    {
        curHealth.SubtractClamped(amount, min: 0, max: maxHealth.Val);
    }

    // temp for testing
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) TakeDamage(10);
    }
}
