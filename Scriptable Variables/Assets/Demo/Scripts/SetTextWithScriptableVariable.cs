using System;
using System.Collections;
using System.Collections.Generic;
using NuiN.ScriptableVariables;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetTextWithScriptableVariable : MonoBehaviour
{
    [SerializeField] Text displayedText;
    [SerializeField] ReadVariable<string> stringVariable;
    [SerializeField] WriteVariable<string> test;
    
    [SerializeField] ReadVariable<int> varInt;
    [SerializeField] WriteVariable<List<int>> varIntList;
    [SerializeField] ReadVariable<int[]> varIntArray;

    [SerializeField] ReadVariable<long> varLong;
    [SerializeField] WriteVariable<List<long>> varLongList;
    [SerializeField] ReadVariable<long[]> varLongArray;

    [SerializeField] ReadVariable<double> varDouble;
    [SerializeField] WriteVariable<List<double>> varDoubleList;
    [SerializeField] ReadVariable<double[]> varDoubleArray;

    [SerializeField] ReadVariable<float> varFloat;
    [SerializeField] WriteVariable<List<float>> varFloatList;
    [SerializeField] ReadVariable<float[]> varFloatArray;

    [SerializeField] ReadVariable<string> varString;
    [SerializeField] WriteVariable<List<string>> varStringList;
    [SerializeField] ReadVariable<string[]> varStringArray;

    [SerializeField] ReadVariable<Vector2> varVector2;
    [SerializeField] WriteVariable<List<Vector2>> varVector2List;
    [SerializeField] ReadVariable<Vector2[]> varVector2Array;

    [SerializeField] ReadVariable<Vector3> varVector3;
    [SerializeField] WriteVariable<List<Vector3>> varVector3List;
    [SerializeField] ReadVariable<Vector3[]> varVector3Array;

    [SerializeField] ReadVariable<Color> varColor;
    [SerializeField] WriteVariable<List<Color>> varColorList;
    [SerializeField] ReadVariable<Color[]> varColorArray;

    [SerializeField] ReadVariable<bool> varBool;
    [SerializeField] WriteVariable<List<bool>> varBoolList;
    [SerializeField] ReadVariable<bool[]> varBoolArray;

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
