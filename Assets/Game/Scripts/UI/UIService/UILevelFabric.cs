using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILevelFabric : MonoBehaviour
{
    [SerializeField] private Level_UI _levelUI;

    private AudioService _audioService;
    private LevelSpawner _levelSpawner;
    private EnemyLevelController _enemyLevelController;
    private GamePhase _gamePhase;
    private bool _isOrientationPortrait;
    private Shooter _shooter;

    public void Init(AudioService audioService, GamePhase gamePhase, bool isOrientationPortrait, LevelSpawner levelSpawner, EnemyLevelController enemyLevelController, Shooter shooter)
    {
        _audioService = audioService;
        _levelSpawner = levelSpawner;
        _enemyLevelController = enemyLevelController;
        _gamePhase = gamePhase;
        _isOrientationPortrait = isOrientationPortrait;
        _shooter = shooter;

    }

    public Level_UI CreateLevelUI()
    {
        Level_UI level_UI = Instantiate(_levelUI, transform);
        level_UI.Init(_audioService, _gamePhase, _isOrientationPortrait, _levelSpawner, _enemyLevelController, _shooter);
        _shooter.SetLevelUI(level_UI);
        return level_UI;
    }
}
