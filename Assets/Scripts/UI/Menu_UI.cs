using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Menu_UI : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Canvas Menu;
    [SerializeField] private Canvas Game;
    public event UnityAction OnGameStarted;


    private void OnEnable()
    {
        _playButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        Menu.gameObject.SetActive(false);
        Game.gameObject.SetActive(true);

        OnGameStarted?.Invoke();
        GamePhase.Activate();
    }
}
