using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] EnemyLevelController _enemyLevelController;
    [SerializeField] private WinPanel _winPanel;
    [SerializeField] private LoosePanel _loosePanel;
    [SerializeField] private Wallet_UI _walletUI;
    [SerializeField] private StrengthSellPanel _strenghtSellPanel;
    [SerializeField] private PickaxeSellPanel _pickaxeSellPanel;
    [SerializeField] private WalletManager _walletManager;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private ObstacleInitializer _obstacleInitializer;
    [SerializeField] private Level_UI _levelUI;
    [SerializeField] private PointerManager _pointerManager;
    [SerializeField] private Menu_UI _menuUI;
    [SerializeField] private PausePanel _pausePanel;
    [SerializeField] private PauseButton _pauseButton;

    public WinPanel WinPanel => _winPanel;
    public LoosePanel LoosePanel => _loosePanel;


    public void Init(Wallet wallet, AudioService audioService,GamePhase gamePhase, LevelSpawner levelSpawner)
    {
        _walletUI.Init(wallet);
        _strenghtSellPanel.Init(wallet);
        _pickaxeSellPanel.Init(wallet);
        _walletManager.Init(wallet);
        _enemyLevelController.Init(audioService);
        _obstacleInitializer.Init(audioService);
        _levelUI.Init(audioService,gamePhase);
        _playerController.Init(gamePhase, audioService);
        _pointerManager.Init(gamePhase);
        _menuUI.Init(gamePhase);
        _pausePanel.Init(levelSpawner, gamePhase);
        _pauseButton.Init(gamePhase);
    }
}
