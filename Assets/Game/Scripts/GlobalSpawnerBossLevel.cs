using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSpawnerBossLevel : GlobalSpawner
{
    [SerializeField] private PlayerPosition _playerPosition;
    
    
    public override void Spawn()
    {
        _playerSpawner.Init(_gamePhase, _audioService);
        PlayerController player = _playerSpawner.Spawn();
        
        _playerPosition.Init(player);

        _pointManagerFabric.Init(_gamePhase, player.transform);
        PointerManager pointerManager = _pointManagerFabric.CreatePointManager();

        _enemyLevelController.Init(_audioService, pointerManager);
        
        _uiLevelFabric.Init(_audioService, _gamePhase, _isOrientationPortrait,_levelSpawner, _enemyLevelController, player.Shooter);
        Level_UI level_UI = _uiLevelFabric.CreateLevelUI();
        
        _enemyLevelController.InitBoss(_isOrientationPortrait, level_UI);
        
        _enemyLevelController.SetLevelUI(level_UI);
        level_UI.gameObject.SetActive(true);
        
        
    }

}
