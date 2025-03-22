using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleEnemy : DamagablePerson, IEnemy
{
    [SerializeField] private Enemy _enemy;
    private EnemyLevelController _enemyLevelController;

    public void Init(AudioService audioService, PointerManager pointerManager, EnemyLevelController enemyLevelController)
    {
        _enemy.Init(audioService, pointerManager);
        _enemyLevelController = enemyLevelController;
    }

    private void OnDestroy()
    {
        _enemyLevelController.DecreaseEnemyCount();
    }
}
