using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private Canvas _bossHealthUI;
    [SerializeField] private BossHealth _bossHealth;
    [SerializeField] private EnemyLevelController _enemyLevelController;

    private void OnEnable()
    {
        _enemyLevelController.OnBossFight += ShowHealth;
        _bossHealth.OnBossDied += HideHealth;
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
