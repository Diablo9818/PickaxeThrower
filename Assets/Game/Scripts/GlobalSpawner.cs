using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSpawner : MonoBehaviour
{
    [SerializeField] private PlayerSpawner _playerSpawner;
    [SerializeField] private PointManagerFabric _pointManagerFabric;
    [SerializeField] private EnemyLevelController _enemyLevelController;
    [SerializeField] private UILevelFabric _uiLevelFabric;

    private GamePhase _gamePhase;
    private AudioService _audioService;
    private bool _isOrientationPortrait;
    private LevelSpawner _levelSpawner;

    public void Init(GamePhase gamePhase, AudioService audioService, bool isOrientationPortrait, LevelSpawner levelSpawner)
    {
        _gamePhase = gamePhase;
        _audioService = audioService;
        _isOrientationPortrait = isOrientationPortrait;
        _levelSpawner = levelSpawner;
    }

    public void Spawn()
    {
        _playerSpawner.Init(_gamePhase, _audioService);
        PlayerController player = _playerSpawner.Spawn();

        _pointManagerFabric.Init(_gamePhase, player.transform);
        PointerManager pointerManager = _pointManagerFabric.CreatePointManager();

        _enemyLevelController.Init(_audioService, pointerManager, _isOrientationPortrait);
        
        _uiLevelFabric.Init(_audioService, _gamePhase, _isOrientationPortrait,_levelSpawner, _enemyLevelController, player.Shooter);
        Level_UI level_UI = _uiLevelFabric.CreateLevelUI();
        
        _enemyLevelController.SetLevelUI(level_UI);
        level_UI.gameObject.SetActive(true);
        
        
    }

    public EnemyLevelController GiveController()
    {
        return _enemyLevelController;
    }
}
