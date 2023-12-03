using NuiN.ScriptableVariables.Variable.References;
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
