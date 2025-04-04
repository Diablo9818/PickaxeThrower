using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private Canvas _portraitBossHealthUI;
    [SerializeField] private Canvas _albumBossHealthUI;
    [SerializeField] private BossHealth _bossHealth;
    [SerializeField] private EnemyLevelController _enemyLevelController;
    [SerializeField] private BossHealthUI _bossHealthUI;


    private bool _isOrientationPortrait;
    private Canvas _bossHealthCanvas;

    public void Init(bool isOrientationPortrait, Level_UI levelUI)
    {
        _isOrientationPortrait = isOrientationPortrait;
        _bossHealth.Initialize(levelUI);
        _bossHealthUI.Initialize(isOrientationPortrait);
    }

    private void OnEnable()
    {
        _enemyLevelController.OnBossFight += ShowHealth;
        _bossHealth.OnBossDied += HideHealth;

        if (_isOrientationPortrait)
        {
            _bossHealthCanvas = _portraitBossHealthUI;
        }
        else
        {
            _bossHealthCanvas = _albumBossHealthUI;
        }
    }

    private void OnDestroy()
    {
        _enemyLevelController.OnBossFight -= ShowHealth;
        _bossHealth.OnBossDied -= HideHealth;
    }

    private void ShowHealth()
    {
        _bossHealthCanvas.gameObject.SetActive(true);
    }

    private void HideHealth()
    {
        _bossHealthCanvas.gameObject.SetActive(false);
    }
}
