using NuiN.ScriptableHarmony.References;
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
