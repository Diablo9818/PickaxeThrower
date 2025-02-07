using LayerLab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_UI : MonoBehaviour
{
    [SerializeField] private WinPanel _portraitWinPanel;
    [SerializeField] private WinPanel _albomWinPanel;
    [SerializeField] private LoosePanel _portraitLoosePanel;
    [SerializeField] private LoosePanel _albomLoosePanel;
    [SerializeField] private AudioClip _winSound;
    [SerializeField] private AudioClip _looseSound;

    private AudioService _audioService;
    private GamePhase _gamePhase;
    private WinPanel _winPanel;
    private LoosePanel _loosePanel;

    public WinPanel WinPanel => _winPanel;
    public LoosePanel LoosePanel => _loosePanel;

    public void Init(AudioService audioService, GamePhase gamePhase, bool isOrintationPortrait)
    {
        _audioService = audioService;
        _gamePhase = gamePhase;

        if(isOrintationPortrait)
        {
            _winPanel = _portraitWinPanel;
            _loosePanel = _portraitLoosePanel;
        }
        else
        {
            _winPanel = _albomWinPanel;
            _loosePanel = _albomLoosePanel;
        }
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
    }
}
