using NuiN.ScriptableVariables.Variable.References;
using UnityEngine;

public class MousePositionSetter : MonoBehaviour
{
    Camera _cam;
    
    [SerializeField] VariableWriter<Vector2> mousePos;

    void Awake() => _cam = FindFirstObjectByType<Camera>();
    
    void Update()
    {
        mousePos.Set(_cam.ScreenToWorldPoint(Input.mousePosition), false);
    }
}
