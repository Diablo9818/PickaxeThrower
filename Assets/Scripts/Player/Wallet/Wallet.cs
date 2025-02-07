using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    private int _coins = 56;
    public event UnityAction<int> TotalCoinsChanged;


    public int Coins => _coins;

    public void AddCoins(int coinsToAdd)
    {
        if (coinsToAdd > 0)
        {
            _coins += coinsToAdd;
            TotalCoinsChanged?.Invoke(Coins);
            //PlayerPrefs.SetInt("Coins", Coins);

            print($"Coins={Coins}");
        }
    }

    public void RemoveCoins(int coinsToRemove) 
    { 
        if (coinsToRemove > 0)
        {
            if(_coins >= coinsToRemove)
            {
                _coins -= coinsToRemove;
                TotalCoinsChanged?.Invoke(Coins);
            }
        } 
    }

    public bool isEnought(int coins)
    {
        if (_coins >= coins)
        {
            return true;
        }

        return false;
    }
}
