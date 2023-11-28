using System;
using System.Collections;
using System.Collections.Generic;
using NuiN.ScriptableVariables;
using UnityEngine;
using UnityEngine.UI;

public class DemoHealthbarUI : MonoBehaviour
{
    [Header("Read Variable")]
    [SerializeField] ReadVariable<float> maxHealth;
    [SerializeField] ReadVariable<float> curHealth;
    
    [Header("UI")]
    [SerializeField] Slider healthSlider;

    void OnEnable()
    {
        curHealth.AddOnChangeHandler(OnHealthChanged);
    }
    void OnDisable()
    {
        curHealth.RemoveOnChangeHandler(OnHealthChanged);
    }

    void OnHealthChanged(float newHealth)
    {
        float sliderVal = newHealth / maxHealth.Val;
        healthSlider.value = sliderVal;
    }
}
