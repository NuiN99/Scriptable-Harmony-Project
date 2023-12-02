using NuiN.ScriptableVariables.Variable.References;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Writers")]
    [SerializeField] VariableWriter<float> maxHealth;
    [SerializeField] VariableWriter<float> curHealth;

    void Start()
    {
        curHealth.Set(maxHealth.Val);
    }

    public void TakeDamage(float amount)
    {
        curHealth.Set(Mathf.Max(curHealth.Val - amount, 0));
    }

    // temp for testing
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) TakeDamage(10);
    }
}
