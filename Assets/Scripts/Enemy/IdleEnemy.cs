using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleEnemy : DamagablePerson, IEnemy
{
    [SerializeField] private EnemyLevelController _enemyLevelController;

    private void OnDestroy()
    {
        _enemyLevelController.DecreaseEnemyCount();
    }
}
