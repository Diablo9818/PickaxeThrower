using LayerLab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_UI : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _loosePanel;
    [SerializeField] private AudioClip _winSound;
    [SerializeField] private AudioClip _looseSound;

    private AudioService _audioService;
    private GamePhase _gamePhase;

    public void Init(AudioService audioService, GamePhase gamePhase)
    {
        _audioService = audioService;
        _gamePhase = gamePhase;
    }

    public void ShowLoseWindow()
    {
        _gamePhase.Pause();
        _audioService.PlaySound(_looseSound, false);
        _loosePanel.gameObject.SetActive(true);
    }

    public void ShowWinWindow()
    {
        _gamePhase.Pause();
        _audioService.PlaySound(_winSound,false);
        _winPanel.gameObject.SetActive(true);
        print("You win");
    }
}
