using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Menu_UI : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Canvas Menu;
    [SerializeField] private Level_UI _levelUI;
    [SerializeField] private Wallet_UI _walletUI;
    [SerializeField] private PickaxeSellPanel _pickaxeSellPanel;
    [SerializeField] private StrengthSellPanel _strengthSellPanel;
    [SerializeField] private TextMeshProUGUI _levelText;

    public event Action OnGameStarted;

    private GamePhase _gamePhase;

    public void Init(GamePhase gamePhase,Wallet wallet, int levelNumber)
    {
        _gamePhase = gamePhase;
        _walletUI.Init(wallet);
        _strengthSellPanel.Init(wallet);
        _pickaxeSellPanel.Init(wallet);
        _levelText.text = levelNumber.ToString();
    }
    private void OnEnable()
    {
        _playButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        Menu.gameObject.SetActive(false);
        OnGameStarted?.Invoke();
        _gamePhase.Activate();
    }
}
