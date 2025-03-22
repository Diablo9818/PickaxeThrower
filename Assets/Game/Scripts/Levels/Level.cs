using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class Level : MonoBehaviour
{
    [SerializeField] private GlobalSpawner _globalSpawner;
    [SerializeField] private WalletManager _walletManager;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private UIFabric _uiFabric;
   
    private Menu_UI _menu_UI;
    private Level_UI _levelUI;

    public void Init(Wallet wallet, AudioService audioService, GamePhase gamePhase, LevelSpawner levelSpawner, bool isOrientationPortrait, int levelNumber)
    {
        _uiFabric.Init(wallet, gamePhase, isOrientationPortrait, levelNumber);
        _menu_UI = _uiFabric.CreateMenuUI();
        _menu_UI.OnGameStarted += SpawnPlayer;
        _walletManager.Init(wallet);
        _globalSpawner.Init(gamePhase, audioService, isOrientationPortrait, levelSpawner);
    }

    private void OnDisable()
    {
        _menu_UI.OnGameStarted -= SpawnPlayer;
    }

    public LoosePanel GetLoosePanel()
    {
        Debug.Log("GotWinPanel");
        return _levelUI.GetLoosePanel();
    }

    public WinPanel GetWinPanel()
    {
        Debug.Log("GotLosePanel");
        return _levelUI.GetWinPanel();
    }

    private void SpawnPlayer()
    {
        _globalSpawner.Spawn();
    }
}
