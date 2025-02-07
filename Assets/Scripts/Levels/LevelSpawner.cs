using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

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
        //_currentLevelIndex = PlayerPrefs.GetInt("CurrentLevel");
        _gamePhase = new GamePhase();
        print("gamePhase created");
        CreateLevel(_currentLevelIndex);
    }


    private void CreateLevel(int levelIndex)
    {
        _gamePhase.Pause();
        Level level = Instantiate(levels[levelIndex]);
        _currentLevel = level;
        InstantiateLevel(_currentLevel);   
    }

    private void InstantiateLevel(Level level)
    {
        level.Init(_wallet, _audioService, _gamePhase, _levelSpawner);
        _winPanel = level.GetWinPanel();
        _loosePanel = level.GetLoosePanel();
        _winPanel.OnNextLevel += GoToNextLevel;
        _loosePanel.OnLevelRestarted += RestartLevel;
    }

    private void GoToNextLevel()
    {
        //_currentLevelIndex++;
        //PlayerPrefs.SetInt("CurrentLevel", _currentLevelIndex);

        if (_currentLevelIndex % 4 == 0)
        {
            ShowAdv();
            print("AdvShow");
        }

        _winPanel.OnNextLevel -= GoToNextLevel;
        _loosePanel.OnLevelRestarted -= RestartLevel;
        int currentLevel = _currentLevelIndex + 1;

        YG2.SetLeaderboard("BestScore", currentLevel);
        Destroy(_currentLevel.gameObject);
        CreateLevel(_currentLevelIndex);
    }

    public void RestartLevel()
    {
        Destroy(_currentLevel.gameObject);
        CreateLevel(_currentLevelIndex);
    }

    public void ShowAdv()
    {
        YG2.InterstitialAdvShow();
    }

    public void UpdateLevelIndex()
    {
        _currentLevelIndex++;
        PlayerPrefs.SetInt("CurrentLevel", _currentLevelIndex);
    }
}
