using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private Button _quitButton;

    public event UnityAction OnNextLevel;


    private void OnEnable()
    {
        _nextLevelButton.onClick.AddListener(GoToNextLevel);
        _quitButton.onClick.AddListener(QuitGame);
    }


    private void OnDisable()
    {
        _nextLevelButton.onClick.RemoveListener(GoToNextLevel);
        _quitButton.onClick.RemoveListener(QuitGame);
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void GoToNextLevel()
    {
        OnNextLevel?.Invoke();
    }
}
