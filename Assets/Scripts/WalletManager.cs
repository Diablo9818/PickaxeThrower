using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletManager : MonoBehaviour
{
    [SerializeField] private RewardEvent _rewardEvent; 
    private Wallet _wallet;


    public void Init(Wallet wallet)
    {
        _wallet = wallet;
    }
    private void OnEnable()
    {
        _rewardEvent.OnRewarded += HandleRewarded;
    }

    private void OnDisable()
    {
        _rewardEvent.OnRewarded -= HandleRewarded;
    }

    private void HandleRewarded(int coinCount)
    {
        _wallet.AddCoins(coinCount);
    }
}
