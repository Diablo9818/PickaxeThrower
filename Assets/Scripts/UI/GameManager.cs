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
    [SerializeField] private BossHealth _bossHealth;
    [SerializeField] private Level_UI _levelUI;


    private void OnEnable()
    {
        _shooter.GameLoosed += ShowLoseWindow;
        _enemyLevelController.GameWin += ShowWinWindow;
        _bossHealth.OnBossDied += ShowWinWindow;
    }

    private void OnDisable()
    {
        _shooter.GameLoosed -= ShowLoseWindow;
        _enemyLevelController.GameWin -= ShowWinWindow;
        _bossHealth.OnBossDied -= ShowWinWindow;
    }

    private void ShowLoseWindow()
    {
        _levelUI.ShowLoseWindow();
        print("GameLoosed");
    }

    private void ShowWinWindow()
    {
        _levelUI.ShowWinWindow();
    }

}
