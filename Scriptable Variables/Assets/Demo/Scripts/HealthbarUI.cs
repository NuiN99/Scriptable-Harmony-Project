using System;
using System.Collections;
using System.Collections.Generic;
using NuiN.ScriptableVariables.References;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarUI : MonoBehaviour
{
    [Header("Readers")]
    [SerializeField] GetVar<float> maxHealth;
    [SerializeField] GetVar<float> curHealth;
    
    [Header("UI")]
    [SerializeField] Slider healthSlider;

    void OnEnable()
    {
        curHealth.SubOnChange(OnHealthChanged);
    }
    void OnDisable()
    {
        curHealth.UnsubOnChange(OnHealthChanged);
    }

    void OnHealthChanged(float newHealth)
    {
        float sliderVal = newHealth / maxHealth.Val;
        healthSlider.value = sliderVal;
    }
}
