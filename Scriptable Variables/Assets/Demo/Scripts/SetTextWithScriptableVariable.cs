using System;
using System.Collections;
using System.Collections.Generic;
using NuiN.ScriptableVariables;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetTextWithScriptableVariable : MonoBehaviour
{
    [SerializeField] ReadVariable<string> stringVariable;
    [SerializeField] WriteVariable<string> test;
    [SerializeField] Text displayedText;

    void Start()
    {
        Test(stringVariable.Val);
    }

    void OnEnable()
    {
        stringVariable.OnChange += Test;
    }
    void OnDisable()
    {
        stringVariable.OnChange -= Test;
    }

    void Test(string val)
    {
        displayedText.text = val;
    }
}
