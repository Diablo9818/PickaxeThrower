using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class Level : MonoBehaviour
{
    [SerializeField] EnemyLevelController _enemyLevelController;
    [SerializeField] private StrengthSellPanel _strenghtSellPanel;
    [SerializeField] private PickaxeSellPanel _pickaxeSellPanel;
    [SerializeField] private WalletManager _walletManager;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private ObstacleInitializer _obstacleInitializer;
    [SerializeField] private Level_UI _levelUI;
    [SerializeField] private PointerManager _pointerManager;
    [SerializeField] private Menu_UI _menuUI;
    [SerializeField] private Menu_UI _albomMenuUI;
    [SerializeField] private PausePanel _pausePanel;
    [SerializeField] private PauseButton _pauseButton;
    [SerializeField] private GameManager _gameManager;

    private bool _isOrientationPortrait;

    private void Awake()
    {
        string deviceType = YG2.envir.deviceType;

        switch (deviceType)
        {
            case "desktop":
                Screen.orientation = ScreenOrientation.LandscapeLeft;
                _albomMenuUI.gameObject.SetActive(true);
                _isOrientationPortrait = false;
                break;
            case "mobile":
                Screen.orientation = ScreenOrientation.Portrait;
                _menuUI.gameObject.SetActive(true);
                _isOrientationPortrait = true;
                break;
            default:
                break;
        }
    }


    public void Init(Wallet wallet, AudioService audioService,GamePhase gamePhase, LevelSpawner levelSpawner)
    {
        _strenghtSellPanel.Init(wallet);
        _pickaxeSellPanel.Init(wallet);
        _walletManager.Init(wallet);
        _enemyLevelController.Init(audioService, _isOrientationPortrait);
        _obstacleInitializer.Init(audioService);
        _levelUI.Init(audioService,gamePhase, _isOrientationPortrait);
        _playerController.Init(gamePhase, audioService);
        _pointerManager.Init(gamePhase);
        _menuUI.Init(gamePhase, wallet);
        _pausePanel.Init(levelSpawner, gamePhase);
        _pauseButton.Init(gamePhase);
        _gameManager.Init(levelSpawner);
        _albomMenuUI.Init(gamePhase,wallet);
    }

    public LoosePanel GetLoosePanel()
    {
        return _levelUI.LoosePanel;
    }

    public WinPanel GetWinPanel()
    {
        return _levelUI.WinPanel;
    }
}
