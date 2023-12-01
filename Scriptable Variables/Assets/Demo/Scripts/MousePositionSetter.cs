using System;
using System.Collections;
using System.Collections.Generic;
using NuiN.ScriptableVariables.References;
using UnityEngine;

public class MousePositionSetter : MonoBehaviour
{
    Camera _cam;
    
    [SerializeField] SetVar<Vector2> mousePos;

    void Awake() => _cam = FindFirstObjectByType<Camera>();
    
    void Update()
    {
        mousePos.Set(_cam.ScreenToWorldPoint(Input.mousePosition), false);
    }
}
