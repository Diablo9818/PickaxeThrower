using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : AbstractFactory
{
    [SerializeField] private IdleEnemyPlatform _idlePlatform;
    [SerializeField] private MovingEnemyPlatform _movingPlatform;
    [SerializeField] private EnemyLevelController _enemyLevelController;

    private AudioService _audioService;
    private PointerManager _pointerManager;

    public void Init(AudioService audioService, PointerManager pointerManager)
    {
        _audioService = audioService;
        _pointerManager = pointerManager;   
    }

    public override void CreateIdleEnemyPlatform(Transform transform)
    {
        IdleEnemyPlatform platform = Instantiate(_idlePlatform, transform);
        platform.transform.SetParent(transform);
        platform.transform.localPosition = Vector3.zero;
        platform.Init(_audioService, _pointerManager, _enemyLevelController);
    }

    public override void CreateMovingEnemyPlatform(Transform transform)
    {
        MovingEnemyPlatform platform = Instantiate(_movingPlatform, transform);
        platform.transform.SetParent(transform);
        platform.transform.localPosition = Vector3.zero;
        platform.Init(_audioService, _pointerManager, _enemyLevelController);
  
    }
}
