using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _pauseButton;

    private LevelSpawner _levelspawner;
    private GamePhase _gamePhase;

    public void Init(LevelSpawner levelSpawner, GamePhase gamePhase)
    {
        _levelspawner = levelSpawner;
        _gamePhase = gamePhase;
    }

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(Restart);
        _continueButton.onClick.AddListener(Continue);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(Restart);
        _continueButton.onClick.RemoveListener(Continue);
    }

    private void Restart()
    {
        _levelspawner.RestartLevel();
    }

    private void Continue()
    {
        _pauseButton.gameObject.SetActive(true);
        //YG2.PauseGame(false);
        gameObject.SetActive(false);
        _gamePhase.Activate();
    }
}
