using NuiN.ScriptableVariables.RuntimeSet.References;
using NuiN.ScriptableVariables.Variable.References;
using UnityEngine;

public class ClosestEnemyToMouseSetter : MonoBehaviour
{
    GameObject _closestEnemy;

    [SerializeField] SetRuntimeSet<GameObject> enemySet;
    [SerializeField] GetVariable<Vector2> mousePosition;

    void Update()
    {
        float closestDist = float.MaxValue;
        foreach (GameObject enemy in enemySet.Items)
        {
            float distFromMouse = Vector3.Distance(mousePosition.Val, enemy.transform.position);
            if (distFromMouse >= closestDist) continue;
            
            closestDist = distFromMouse;
            _closestEnemy = enemy;
        }

        foreach (GameObject enemy in enemySet.Items)
        {
            SpriteRenderer enemySR = enemy.GetComponent<SpriteRenderer>();
            enemySR.color = enemy == _closestEnemy ? Color.red : Color.blue;
        }
    }
}
