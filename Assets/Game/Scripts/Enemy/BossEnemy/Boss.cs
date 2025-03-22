using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private Canvas _portraitBossHealthUI;
    [SerializeField] private Canvas _albumBossHealthUI;
    [SerializeField] private BossHealth _bossHealth;
    [SerializeField] private EnemyLevelController _enemyLevelController;

    private bool _isOrientationPortrait;
    private Canvas _bossHealthUI;

    public void Init(bool isOrientationPortrait)
    {
        _isOrientationPortrait = isOrientationPortrait;
    }

    private void OnEnable()
    {
        _enemyLevelController.OnBossFight += ShowHealth;
        _bossHealth.OnBossDied += HideHealth;

        if (_isOrientationPortrait)
        {
            _bossHealthUI = _portraitBossHealthUI;
        }
        else
        {
            _bossHealthUI = _albumBossHealthUI;
        }
    }

    private void OnDestroy()
    {
        _enemyLevelController.OnBossFight -= ShowHealth;
        _bossHealth.OnBossDied -= HideHealth;
    }

    private void ShowHealth()
    {
        _bossHealthUI.gameObject.SetActive(true);
    }

    private void HideHealth()
    {
        _bossHealthUI.gameObject.SetActive(false);
    }
}
