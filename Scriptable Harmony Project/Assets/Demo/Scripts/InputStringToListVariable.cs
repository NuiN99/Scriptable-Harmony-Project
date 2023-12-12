using System;
using System.Collections;
using System.Collections.Generic;
using NuiN.ScriptableHarmony.References;
using UnityEngine;
using UnityEngine.UI;

public class InputStringToListVariable : MonoBehaviour
{
    [SerializeField] InputField nameInput;
    [SerializeField] Button clearAllButton;
    [SerializeField] SetListVariable<string> names;

    void OnEnable()
    {
        nameInput.onSubmit.AddListener(names.Add);
        clearAllButton.onClick.AddListener(names.Clear);
    }
    void OnDisable()
    {
        nameInput.onSubmit.RemoveListener(names.Add);
        clearAllButton.onClick.RemoveListener(names.Clear);
    }
}
