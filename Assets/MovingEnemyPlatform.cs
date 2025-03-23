using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemyPlatform : MonoBehaviour, IEnemyPlatform
{
    [SerializeField] private MovingEnemy _enemy;
    [SerializeField] private DestroyableObstacle _obstacle;
    
    public void Init(AudioService audioService, PointerManager pointerManager, EnemyLevelController enemyLevelController)
    {
        _enemy.Init(audioService, pointerManager, enemyLevelController);
        _obstacle.Init(audioService);
    }
}
