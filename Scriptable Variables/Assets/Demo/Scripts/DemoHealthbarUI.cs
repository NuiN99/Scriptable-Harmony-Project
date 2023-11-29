using System;
using System.Collections;
using System.Collections.Generic;
using NuiN.ScriptableVariables.References;
using UnityEngine;
using UnityEngine.UI;

public class DemoHealthbarUI : MonoBehaviour
{
    [Header("Readers")]
    [SerializeField] ReadVariable<float> maxHealth;
    [SerializeField] ReadVariable<float> curHealth;
    
    [Header("UI")]
    [SerializeField] Slider healthSlider;

    void OnEnable()
    {
        curHealth.AddOnChangeHandler(OnHealthChanged);
        curHealth.AddOnChangeHistoryHandler(OnHealthChangedHistory);
    }
    void OnDisable()
    {
        curHealth.RemoveOnChangeHandler(OnHealthChanged);
        curHealth.RemoveOnChangeHistoryHandler(OnHealthChangedHistory);
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
