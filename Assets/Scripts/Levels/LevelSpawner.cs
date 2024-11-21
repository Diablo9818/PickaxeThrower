using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField] private List<Level> levels;
    [SerializeField] private Wallet _wallet;

    private int _currentLevelIndex=0;

    private Level _currentLevel;
    private WinPanel _winPanel;
    private LoosePanel _loosePanel;

    private void Start()
    {
        CreateLevel(_currentLevelIndex);
    }


    private void CreateLevel(int levelIndex)
    {
        GamePhase.Pause();
        Level level = Instantiate(levels[levelIndex]);
        _currentLevel = level;
        InstantiateLevel(_currentLevel);
        
    }

    private void InstantiateLevel(Level level)
    {
        level.Init(_wallet);
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

    private void RestartLevel()
    {
        Destroy(_currentLevel.gameObject);
        CreateLevel(_currentLevelIndex);
    }
}
