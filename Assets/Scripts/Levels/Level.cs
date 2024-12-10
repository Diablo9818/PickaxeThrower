using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] EnemyLevelController _enemyLevelController;
    [SerializeField] private List<DamagablePerson> _enemies;
    [SerializeField] private WinPanel _winPanel;
    [SerializeField] private LoosePanel _loosePanel;
    [SerializeField] private Wallet_UI _walletUI;
    [SerializeField] private StrenghtSellPanel _strenghtSellPanel;
    [SerializeField] private PickaxeSellPanel _pickaxeSellPanel;
    [SerializeField] private WalletManager _walletManager;

    public WinPanel WinPanel => _winPanel;
    public LoosePanel LoosePanel => _loosePanel;


    public void Init(Wallet wallet)
    {
        _walletUI.Init(wallet);
        _strenghtSellPanel.Init(wallet);
        _pickaxeSellPanel.Init(wallet);
        _walletManager.Init(wallet);
    }
}
