using NuiN.ScriptableHarmony.References;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarUI : MonoBehaviour
{
    [Header("Getters")]
    [SerializeField] GetVariable<float> maxHealth;
    [SerializeField] GetVariable<float> curHealth;
    
    [Header("UI")]
    [SerializeField] Image healthSlider;

    void OnEnable()
    {
        curHealth.SubOnChange(OnHealthChanged);
    }
    void OnDisable()
    {
        curHealth.UnSubOnChange(OnHealthChanged);
    }

    void OnHealthChanged(float newHealth)
    {
        float fillAmount = newHealth / maxHealth.Val;
        healthSlider.fillAmount = fillAmount;
    }
}
