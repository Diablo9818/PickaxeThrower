using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField] private List<Level> levels;
    [SerializeField] private int _currentLevelIndex=0;
    [SerializeField] private LevelSpawner _levelSpawner;

    private Level _currentLevel;
    private WinPanel _winPanel;
    private LoosePanel _loosePanel;
    private GamePhase _gamePhase;
    private Wallet _wallet;
    private AudioService _audioService;

    private bool _isOrientationPortrait;


    private void Start()
    {
        //_currentLevelIndex = PlayerPrefs.GetInt("CurrentLevel");
        CreateLevel(_currentLevelIndex);
    }

    public void Init(AudioService audioService, Wallet wallet, bool isOrientationPortrait, GamePhase gamePhase)
    {
        _audioService = audioService;
        _wallet = wallet;
        _isOrientationPortrait = isOrientationPortrait;
        _gamePhase = gamePhase;
    }


    private void CreateLevel(int levelIndex)
    {
        _gamePhase.Pause();
        Level level = Instantiate(levels[levelIndex]);
        _currentLevel = level;
        InitializeLevel(_currentLevel);   
    }

    private void InitializeLevel(Level level)
    {
        level.Init(_wallet, _audioService, _gamePhase, _levelSpawner, _isOrientationPortrait);
    }

    public void GoToNextLevel()
    {
        Destroy(_currentLevel.gameObject);
        //_currentLevelIndex++;
        //PlayerPrefs.SetInt("CurrentLevel", _currentLevelIndex);

        if (_currentLevelIndex % 4 == 0)
        {
            ShowAdv();
            print("AdvShow");
        }
        
        int currentLevel = _currentLevelIndex + 1;

        YG2.SetLeaderboard("BestScore", currentLevel);
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
