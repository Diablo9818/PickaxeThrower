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
    private int _levelNumber;



    public void Init(Wallet wallet, GamePhase gamePhase, bool isOrientationPortrait, int levelNumber)
    {
        _wallet = wallet;
        _gamePhase = gamePhase;
        _isOrientationPortrait = isOrientationPortrait;
        _levelNumber = levelNumber;
    }


    public Menu_UI CreateMenuUI()
    {
        if (_isOrientationPortrait)
        {
            Menu_UI menuUI = Instantiate(_portraitMenuUI, transform);
            menuUI.Init(_gamePhase, _wallet, _levelNumber);
            return menuUI;
        }
        else
        {
            Menu_UI menuUI = Instantiate(_albomMenuUI, transform);
            menuUI.Init(_gamePhase, _wallet,_levelNumber);
            return menuUI;
        }
    }
}
