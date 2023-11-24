using System;
using System.Collections;
using System.Collections.Generic;
using NuiN.ScriptableVariables;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class WriteSceneTextVariable : MonoBehaviour
{
    [SerializeField] WriteVariable<string> stringVariable;

    [SerializeField] string[] possibleStrings;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            stringVariable.Val = possibleStrings[Random.Range(0, possibleStrings.Length)];
        }

        if (Input.GetMouseButtonDown(1))
        {
            SceneManager.LoadScene("DemoSceneSwitchTest");
        }
    }
}
