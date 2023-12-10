using NuiN.ScriptableHarmony.References;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarUI : MonoBehaviour
{
    [Header("Getters")]
    [SerializeField] GetVariable<float> maxHealth;
    [SerializeField] GetVariable<float> curHealth;
    
    [Header("UI")]
    [SerializeField] Slider healthSlider;

    void OnEnable()
    {
        curHealth.SubOnChange(OnHealthChanged);
        OnHealthChanged(curHealth.Val);
    }
    void OnDisable()
    {
        curHealth.UnSubOnChange(OnHealthChanged);
    }

    void OnHealthChanged(float newHealth)
    {
        float sliderVal = newHealth / maxHealth.Val;
        healthSlider.value = sliderVal;
    }
}
