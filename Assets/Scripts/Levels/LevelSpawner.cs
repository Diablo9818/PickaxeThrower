using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField] private List<Level> levels;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private AudioService _audioService;
    [SerializeField] private int _currentLevelIndex=0;
    [SerializeField] private LevelSpawner _levelSpawner;

    private Level _currentLevel;
    private WinPanel _winPanel;
    private LoosePanel _loosePanel;
    private GamePhase _gamePhase;


    private void Start()
    {
        CreateLevel(_currentLevelIndex);
    }


    private void CreateLevel(int levelIndex)
    {
        _gamePhase = new GamePhase();
        _gamePhase.Pause();
        Level level = Instantiate(levels[levelIndex]);
        _currentLevel = level;
        InstantiateLevel(_currentLevel);   
    }

    private void InstantiateLevel(Level level)
    {
        level.Init(_wallet, _audioService, _gamePhase, _levelSpawner);
        _winPanel = level.WinPanel;
        _loosePanel = level.LoosePanel;
        _winPanel.OnNextLevel += GoToNextLevel;
        _loosePanel.OnLevelRestarted += RestartLevel;
    }

    private void GoToNextLevel()
    {
        _currentLevelIndex++;
        _winPanel.OnNextLevel -= GoToNextLevel;
        _loosePanel.OnLevelRestarted -= RestartLevel;
        Destroy(_currentLevel.gameObject);
        CreateLevel(_currentLevelIndex);
    }

    public void RestartLevel()
    {
        Destroy(_currentLevel.gameObject);
        CreateLevel(_currentLevelIndex);
    }
}
