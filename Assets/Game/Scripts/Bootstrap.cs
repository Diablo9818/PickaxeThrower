using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private AudioService _audioService;
    [SerializeField] private LevelSpawner _levelSpawner;
    [SerializeField] private MenuChooser _menuChooser;
    [SerializeField] private string _menuSceneName;
    [SerializeField] private string _gameSceneName;

    private bool _isOrientationPortrait;
    private MenuChooser _cashedMenuChooser;
    private GamePhase _gamePhase;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        string deviceType = YG2.envir.deviceType;

        switch (deviceType)
        {
            case "desktop":
                Screen.orientation = ScreenOrientation.LandscapeLeft;
                _isOrientationPortrait = false;
                break;
            case "mobile":
                Screen.orientation = ScreenOrientation.Portrait;
                _isOrientationPortrait = true;
                break;
        }

        _cashedMenuChooser = Instantiate(_menuChooser);
        _gamePhase = new GamePhase();
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void StartGame()
    {
        AudioService audioService = Instantiate(_audioService);
        Wallet wallet = Instantiate(_wallet);
        LevelSpawner levelSpawner = Instantiate(_levelSpawner);
        levelSpawner.Init(audioService, wallet, _isOrientationPortrait, _gamePhase);
    }

    private void CreateMenu()
    {
        _cashedMenuChooser.Init(_isOrientationPortrait);
        _cashedMenuChooser.ShowMenu();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == _gameSceneName)
        {
            StartGame();
        }

        if(scene.name == _menuSceneName)
        {
            CreateMenu();
        }
    }
}
