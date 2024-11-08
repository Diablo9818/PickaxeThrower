using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField] private List<Level> levels;
    [SerializeField] private GameObject _demoLevel;
    [SerializeField] private Wallet _wallet;

    private int _currentLevelIndex=0;

    private Level _currentLevel;
    private WinPanel _winPanel;

    private void Start()
    {
        CreateLevel();
    }


    public void CreateLevel()
    {
        GamePhase.Pause();
        _demoLevel.SetActive(false);
        Level level = Instantiate(levels[4]);
        _currentLevel = level;
        level.Init(_wallet);
        _winPanel = level.WinPanel;
        _winPanel.OnNextLevel += GoToNextLevel;
        _currentLevelIndex++;
    }

    private void GoToNextLevel()
    {
        _winPanel.OnNextLevel -= GoToNextLevel;
        _demoLevel.SetActive(true);
        Destroy(_currentLevel.gameObject);
        CreateLevel();
    }
}
