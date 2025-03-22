using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UIFabric : MonoBehaviour
{
    [SerializeField] private Menu_UI _albomMenuUI;
    [SerializeField] private Menu_UI _portraitMenuUI;


    private Wallet _wallet;
    private GamePhase _gamePhase;
    private bool _isOrientationPortrait;



    public void Init(Wallet wallet, GamePhase gamePhase, bool isOrientationPortrait)
    {
        _wallet = wallet;
        _gamePhase = gamePhase;
        _isOrientationPortrait = isOrientationPortrait;
    }


    public Menu_UI CreateMenuUI()
    {
        if (_isOrientationPortrait)
        {
            Menu_UI menuUI = Instantiate(_portraitMenuUI, transform);
            menuUI.Init(_gamePhase, _wallet);
            return menuUI;
        }
        else
        {
            Menu_UI menuUI = Instantiate(_albomMenuUI, transform);
            menuUI.Init(_gamePhase, _wallet);
            return menuUI;
        }
    }
}
