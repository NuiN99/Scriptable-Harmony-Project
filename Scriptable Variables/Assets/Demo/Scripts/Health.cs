using System;
using NuiN.ScriptableVariables.References;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Writers")]
    [SerializeField] SetVar<float> maxHealth;
    [SerializeField] SetVar<float> curHealth;

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
