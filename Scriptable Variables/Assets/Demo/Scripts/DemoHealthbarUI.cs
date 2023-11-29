using System;
using System.Collections;
using System.Collections.Generic;
using NuiN.ScriptableVariables.References;
using UnityEngine;
using UnityEngine.UI;

public class DemoHealthbarUI : MonoBehaviour
{
    [Header("Readers")]
    [SerializeField] GetVar<float> maxHealth;
    [SerializeField] GetVar<float> curHealth;
    
    [Header("UI")]
    [SerializeField] Slider healthSlider;

    void OnEnable()
    {
        curHealth.SubOnChange(OnHealthChanged);
        curHealth.SubOnChangeWithOld(OnHealthChangedHistory);
    }
    void OnDisable()
    {
        curHealth.UnsubOnChange(OnHealthChanged);
        curHealth.UnsubOnChangeWithOld(OnHealthChangedHistory);
    }

    void OnHealthChanged(float newHealth)
    {
        float sliderVal = newHealth / maxHealth.Val;
        healthSlider.value = sliderVal;
    }

    void OnHealthChangedHistory(float oldHealth, float newHealth)
    {
        Debug.Log($"Old Health: {oldHealth}\nNew Health: {newHealth}");
    }
}
