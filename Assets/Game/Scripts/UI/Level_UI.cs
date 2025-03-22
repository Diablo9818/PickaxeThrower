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
    [SerializeField] private PausePanel _pausePanel;
    [SerializeField] private PauseButton _pauseButton;
    [SerializeField] private AudioClip _winSound;
    [SerializeField] private AudioClip _looseSound;
    [SerializeField] private  EnemyCountShower _enemyCountShower;
    [SerializeField] private PickaxeCountShower _pickaxeCountShower;

    private AudioService _audioService;
    private GamePhase _gamePhase;
    private WinPanel _winPanel;
    private LoosePanel _loosePanel;

    public WinPanel WinPanel => _winPanel;
    public LoosePanel LoosePanel => _loosePanel;

    public void Init(AudioService audioService, GamePhase gamePhase, bool isOrintationPortrait, LevelSpawner levelSpawner, EnemyLevelController enemyLevelController, Shooter shooter)
    {
        _audioService = audioService;
        _gamePhase = gamePhase;
        _pausePanel.Init(levelSpawner, gamePhase);
        _pauseButton.Init(gamePhase);
        _enemyCountShower.Init(enemyLevelController);
        _pickaxeCountShower.Init(shooter);

        if (isOrintationPortrait)
        {
            _winPanel = _portraitWinPanel;
            _loosePanel = _portraitLoosePanel;
            
  
            print("panels are portrait");
        }
        else
        {
            _winPanel = _albomWinPanel;
            _loosePanel = _albomLoosePanel;
            print("panels are albom");
        }
        
        _winPanel.Init(levelSpawner);
        _loosePanel.Init(levelSpawner);
    }

    public WinPanel GetWinPanel()
    {
        print(" Got _winPanel");
        return _winPanel;
    }

    public LoosePanel GetLoosePanel()
    {
        print(" Got _loosePanel");
        return _loosePanel;
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
