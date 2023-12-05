using NuiN.ScriptableVariables.References;
using NuiN.ScriptableVariables.RuntimeSet.References;
using NuiN.ScriptableVariables.Variable.References;
using UnityEngine;

public class ClosestEnemyToMouseSetter : MonoBehaviour
{
    Enemy _closestEnemy;

    [SerializeField] SetRuntimeSet<Enemy> enemySet;
    [SerializeField] GetVariable<Vector2> mousePosition;

    void Update()
    {
        float closestDist = float.MaxValue;
        foreach (Enemy enemy in enemySet.Entities)
        {
            float distFromMouse = Vector3.Distance(mousePosition.Val, enemy.transform.position);
            if (distFromMouse >= closestDist) continue;
            
            closestDist = distFromMouse;
            _closestEnemy = enemy;
        }

        foreach (Enemy enemy in enemySet.Entities)
        {
            Color enemyColor = enemy == _closestEnemy
                ? Color.red
                : Color.blue;
            
            enemy.SetColor(enemyColor);
        }
    }
}
