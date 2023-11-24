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

    [SerializeField] Text displayedText;

    void Update()
    {
        displayedText.text = stringVariable.Val;
    }
}
