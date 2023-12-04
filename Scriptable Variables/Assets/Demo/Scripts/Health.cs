using System;
using NuiN.ScriptableVariables.Variable.References;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header("Writers")]
    [SerializeField] SetVariable<float> maxHealth;
    [SerializeField] SetVariable<float> curHealth;

    static Health instance;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);
    }

    public void TakeDamage(float amount)
    {
        curHealth.SubtractClamped(amount, min: 0, max: maxHealth.Val);
    }

    // temp for testing
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if(Input.GetMouseButtonDown(0)) TakeDamage(10);
    }
}
