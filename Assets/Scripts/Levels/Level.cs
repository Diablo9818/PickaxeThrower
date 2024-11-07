using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] EnemyLevelController _enemyLevelController;
    [SerializeField] private List<DamagablePerson> _enemies;
    [SerializeField] private WinPanel _winPanel;
    [SerializeField] private Wallet_UI _walletUI;
    [SerializeField] private StrenghtSellPanel _strenghtSellPanel;
    [SerializeField] private PickaxeSellPanel _pickaxeSellPanel;

    public WinPanel WinPanel => _winPanel;


    public void Init(Wallet wallet)
    {
        _walletUI.Init(wallet);
        _strenghtSellPanel.Init(wallet);
        _pickaxeSellPanel.Init(wallet);

        foreach (DamagablePerson enemy in _enemies)
        {
            Enemy currentEnemy = enemy.GetComponentInChildren<Enemy>();
            currentEnemy.Init(wallet);
        }
    }
}
