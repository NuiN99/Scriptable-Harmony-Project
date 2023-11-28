using System;
using System.Collections;
using System.Collections.Generic;
using NuiN.ScriptableVariables.References;
using UnityEngine;

public class DemoHealth : MonoBehaviour
{
    [Header("Writers")]
    [SerializeField] WriteVariable<float> maxHealth;
    [SerializeField] WriteVariable<float> curHealth;

    void Start()
    {
        curHealth.Val = maxHealth.Val;
    }

    public void TakeDamage(float amount)
    {
        curHealth.Val = Mathf.Max(curHealth.Val - amount, 0);
    }

    // temp for testing
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) TakeDamage(10);
    }
}
