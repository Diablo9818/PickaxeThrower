using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LoosePanel : MonoBehaviour
{
    [SerializeField] private Button _restartLevelButton;
    [SerializeField] private Button _quitButton;

    public event UnityAction OnLevelRestarted;


    private void OnEnable()
    {
        _restartLevelButton.onClick.AddListener(RestartLevel);
        _quitButton.onClick.AddListener(QuitGame);
    }


    private void OnDisable()
    {
        _restartLevelButton.onClick.RemoveListener(RestartLevel);
        _quitButton.onClick.RemoveListener(QuitGame);
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void RestartLevel()
    {
        OnLevelRestarted?.Invoke();
        print("Level restarted!");
    }
}
