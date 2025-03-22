using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBoss : GameManager
{
    [SerializeField] private BossHealth _bossHealth;

    private void OnEnable()
    {
        _bossHealth.OnBossDied += ShowWinWindow;
    }

    private void OnDisable()
    {
        _bossHealth.OnBossDied -= ShowWinWindow;
    }
}
