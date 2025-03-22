using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : AbstractFactory
{
    [SerializeField] private IdleEnemyPlatform _platform;
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
        IdleEnemyPlatform platform = Instantiate(_platform, transform);
        platform.transform.SetParent(transform);
        platform.transform.localPosition = Vector3.zero;
        platform.Init(_audioService, _pointerManager, _enemyLevelController);
    }

    public override IEnemyPlatform CreateMovingEnemyPlatform()
    {
        return Instantiate(_platform, transform);
    }
}
