using NuiN.ScriptableHarmony.References;
using UnityEngine;

public class ClosestEnemyToMouseSetter : MonoBehaviour
{
    Enemy _closestEnemy;

    [SerializeField] SetRuntimeSet<Enemy> enemySet;
    [SerializeField] GetVariable<Vector2> mousePosition;
    [SerializeField] GetListVariable<bool> test;

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
