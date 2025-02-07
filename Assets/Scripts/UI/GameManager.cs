using LayerLab;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Shooter _shooter;
    [SerializeField] private EnemyLevelController _enemyLevelController;
    [SerializeField] private LevelSpawner _levelSpawner;

    [SerializeField] protected Level_UI _levelUI;


    private void OnEnable()
    {
        _shooter.GameLoosed += ShowLoseWindow;
        _enemyLevelController.GameWin += ShowWinWindow;
    }

    private void OnDisable()
    {
        _shooter.GameLoosed -= ShowLoseWindow;
        _enemyLevelController.GameWin -= ShowWinWindow;
    }

    public void Init(LevelSpawner levelSpawner)
    {
        _levelSpawner = levelSpawner;
    }

    private void ShowLoseWindow()
    {
        _levelUI.ShowLoseWindow();
        print("GameLoosed");
    }

    protected void ShowWinWindow()
    {
        _levelUI.ShowWinWindow();
        _levelSpawner.UpdateLevelIndex();
    }

}
