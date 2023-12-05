using NuiN.ScriptableVariables.References;
using NuiN.ScriptableVariables.Variable.References;
using UnityEngine;

public class MousePositionSetter : MonoBehaviour
{
    Camera _cam;
    
    [SerializeField] SetVariable<Vector2> mousePos;

    void Awake() => _cam = FindFirstObjectByType<Camera>();
    
    void Update()
    {
        mousePos.Set(_cam.ScreenToWorldPoint(Input.mousePosition), false);
    }
}
