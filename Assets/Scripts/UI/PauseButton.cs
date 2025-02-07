using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private PausePanel _pausePanel;
    [SerializeField] private Button _pauseButton;

    private GamePhase _gamePhase;

    public void Init(GamePhase gamePhase)
    {
        _gamePhase = gamePhase;
    } 

    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(Pause);
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(Pause);
    }

    private void Pause()
    {
        //YG2.PauseGame(true);
        _pausePanel.gameObject.SetActive(true);
        gameObject.SetActive(false);
        _gamePhase.Pause();
    }
}
