using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : DamagablePerson, IEnemy
{
    [SerializeField] private EnemyLevelController _enemyLevelController;

    public void Init(EnemyLevelController enemyLevelController)
    {
        _enemyLevelController = enemyLevelController;
    }

    private void OnDestroy()
    {
        _enemyLevelController.DecreaseEnemyCount();
    }
}
